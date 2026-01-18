using UserService.Domain.DTO;
using UserService.Domain.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace UserService.API.Controllers
{
    [Route("api/[controller]")] //api/auth
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest("Invalid Registration Data.");
            }

            AuthenticationResponse? authenticationResponse = await _userService.Register(registerRequest);

            if (authenticationResponse == null || !authenticationResponse.Sucess)
            {
                return BadRequest(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Invalid Login Data.");
            }
            AuthenticationResponse? authenticationResponse = await _userService.Login(loginRequest);
            if (authenticationResponse == null || !authenticationResponse.Sucess)
            {
                return Unauthorized(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }
    }
}
