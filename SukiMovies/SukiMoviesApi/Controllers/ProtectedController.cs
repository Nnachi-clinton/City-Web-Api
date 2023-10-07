using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SukiMoviesApi.Models.DTO;

namespace SukiMoviesApi.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    [Authorize]
    public class ProtectedController : ControllerBase
    {


        public IActionResult GetData()
        {
            var status = new Status
            {
                StatusCode = 200,
                Message = "Data from protected controller"
            };
            return Ok(status);
        }
    }
}
