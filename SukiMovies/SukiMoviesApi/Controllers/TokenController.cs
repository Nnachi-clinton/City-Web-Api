using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SukiMoviesApi.Models.Domain;
using SukiMoviesApi.Models.DTO;
using SukiMoviesApi.Repositories.Abstract;

namespace SukiMoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService, DatabaseContext databaseContext)
        {
            _tokenService = tokenService;
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public IActionResult Refresh(RefreshTokenRequest model)
        {
            if (model is null)
                return BadRequest("Invalid client request");
            string accessToken = model.AccessToken;
            string refreshToken = model.RefreshToken;
            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name;
            var user = _databaseContext.TokenInfos.SingleOrDefault(u => u.UserName == username);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiry <= DateTime.Now)
                return BadRequest("Invalid client request");
            var newAccessToken = _tokenService.GetToken(principal.Claims);
            var newRefreshToken = _tokenService.GetRefreshToken();
            user.RefreshToken = newRefreshToken;
            _databaseContext.SaveChanges();
            return Ok(new RefreshTokenRequest()
            {
                AccessToken = newAccessToken.TokenString,
                RefreshToken = newRefreshToken
            });
        }


        [HttpPost, Authorize]
        public IActionResult Revoke()
        {
            try
            {
                var username = User.Identity.Name;
                var user = _databaseContext.TokenInfos.SingleOrDefault(u => u.UserName == username);
                if (user is null)
                    return BadRequest();
                user.RefreshToken = null;
                _databaseContext.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    
}
