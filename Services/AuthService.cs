using Web_API_Project.DTOs.Auth;
using Web_API_Project.Entities;
using Web_API_Project.Interfaces;
using Web_API_Project.Repositories;

namespace Web_API_Project.Services
{
    public class AuthService(IUserRepository userRepository) :IAuthService
    {
        private readonly IUserRepository _userRepository = userRepository;

     

        public async Task RegisterAsync(RegisterRequestDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if(existingUser != null)
            {
                throw new Exception("Email already exists"); 
            }

            var user = new User
            {
                Username =dto.Username,
                Email= dto.Email,
                PasswordHash= HashPassword(dto.Password),
                CreatedOn=DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<User> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null)
            {
                return null;
            }
            var verifiedPassword = VerifyPassword(dto.Password, user.PasswordHash);

            if (!verifiedPassword)
            {
                return null;
            }

            return user;
        }
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
