using Web_API_Project.DTOs.Product;
using Web_API_Project.Entities;
using Web_API_Project.Interfaces;
using Web_API_Project.Repositories;

namespace Web_API_Project.Services
{
    public class ProductService(IProductRepository repository) : IProductService
    {
        private readonly IProductRepository _repository = repository;
        public async Task AddProductAsync(ProductRequestDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                CreatedOn = DateTime.UtcNow
            };
            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                return;
            }
            await _repository.DeleteAsync(product);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
          return await _repository.GetAllAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateProductAsync(int id, ProductRequestDto dto)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null) {
                return;  
            }

            product.Name=dto.Name;
            product.Description=dto.Description;
            product.Price=dto.Price;
            product.UpdatedOn=DateTime.UtcNow;

            await _repository.UpdateAsync(product);
            await _repository.SaveChangesAsync();
        }
    }
}
