
using Web_API_Project.Entities;

namespace Web_API_Project.Repositories
{
    public interface IProductRepository
    {
         Task AddAsync(Product product);
         Task<List<Product>> GetAllAsync();
         Task<Product?> GetByIdAsync(int id);
         Task UpdateAsync(Product product);
         Task DeleteAsync(Product product);
         Task SaveChangesAsync();
    }

}
