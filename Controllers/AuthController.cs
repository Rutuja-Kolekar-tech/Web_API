using Microsoft.AspNetCore.Mvc;
using Web_API_Project.DTOs.Auth;
using Web_API_Project.Interfaces;

namespace Web_API_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService= authService;
        
       
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto dto)
        {
            await _authService.RegisterAsync(dto);
            return Ok(new
            {
                message = "User registered successfully"
            });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
           var isValid =  await _authService.LoginAsync(dto);
            if (!isValid)
            {
                return Unauthorized(new
                {
                    Message = "Invalid email or password"
                });
            }
            else
            {
                return Ok(new
                {

                    Message = "Login successfull"

                });
            }
        }
    }

}
    