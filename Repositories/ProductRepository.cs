using Microsoft.EntityFrameworkCore;
using Web_API_Project.Data;
using Web_API_Project.Entities;

namespace Web_API_Project.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public  Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            return Task.CompletedTask;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public  Task UpdateAsync(Product product)
        {
             _context.Products.Update(product);
            return Task.CompletedTask;
        }
    }
}
