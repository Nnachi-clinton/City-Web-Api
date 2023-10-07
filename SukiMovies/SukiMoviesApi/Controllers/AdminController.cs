using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SukiMoviesApi.Models.DTO;

namespace SukiMoviesApi.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        public IActionResult GetData()
        {

            var status = new Status
            {
                StatusCode = 200,
                Message = "Data from Admin controller"
            };
            return Ok(status);
        }
    }
}
