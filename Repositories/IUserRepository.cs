using Web_API_Project.Entities;

namespace Web_API_Project.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task SaveChangesAsync();

    }
}
    