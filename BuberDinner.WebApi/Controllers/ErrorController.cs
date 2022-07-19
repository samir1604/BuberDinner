using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {        
        public IActionResult Error()
        {
            return Problem();
        }
    }
}
