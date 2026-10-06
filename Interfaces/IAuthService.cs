using Web_API_Project.DTOs.Auth;
using Web_API_Project.Entities;

namespace Web_API_Project.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterRequestDto dto);
        Task<User> LoginAsync(LoginDto dto);
        string HashPassword(string password);
        bool VerifyPassword(string password, string hash);
    }
}
