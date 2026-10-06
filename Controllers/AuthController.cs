using Microsoft.AspNetCore.Mvc;
using Web_API_Project.DTOs.Auth;
using Web_API_Project.Interfaces;
using Web_API_Project.Services;

namespace Web_API_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService, JwtService jwtService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;
        private readonly JwtService _jwtService= jwtService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto dto)
        {
            await _authService.RegisterAsync(dto);

            return Ok(new
            {
                message = "User registered successfully",
            });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
           var user =  await _authService.LoginAsync(dto);
            if (user==null)
            {
                return Unauthorized(new
                {
                    Message = "Invalid email or password"
                });
            }
            else
            {
                var token = _jwtService.GenerateToken(user.Id,user.Username);
                return Ok(new
                {

                    Message = "Login success",
                    Token = token

                });
            }
        }

        [HttpPost("logout")]
        public Task<IActionResult> Logout()
        {
            return Task.FromResult<IActionResult>(Ok(new
            {
                Message= "Logout successful."
            }));
        }

         

    }



}
    