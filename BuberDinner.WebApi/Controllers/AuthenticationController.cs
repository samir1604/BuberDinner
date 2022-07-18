using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationService.Register(
                request.FirstName, request.LastName, request.Email, request.Password);

            var response = new AuthenticationResponse
            {
                Id = authResult.User.Id,
                FirstName = authResult.User.FirstName,
                LastName = authResult.User.LastName, 
                Email = authResult.User.Email,   
                Token =  authResult.Token
            }; 

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(request.Email, request.Password);

            var response = new AuthenticationResponse
            {
                Id = authResult.User.Id,
                FirstName = authResult.User.FirstName,
                LastName = authResult.User.LastName,
                Email = authResult.User.Email,
                Token = authResult.Token
            };

            return Ok(response);
        }
    }
}
