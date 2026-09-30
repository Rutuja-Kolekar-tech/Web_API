using Web_API_Project.DTOs.Auth;

namespace Web_API_Project.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterRequestDto dto);
    }
}
