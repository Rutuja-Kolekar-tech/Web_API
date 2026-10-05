using Web_API_Project.DTOs.Product;
using Web_API_Project.Entities;

namespace Web_API_Project.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(ProductRequestDto dto);
        Task<List<Product>> GetAllProductAsync();
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync( int id ,ProductRequestDto dto);
        Task<Product?> GetProductByIdAsync(int  id);

    }
}
