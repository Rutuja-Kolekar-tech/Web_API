using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_API_Project.DTOs.Product;
using Web_API_Project.Interfaces;

namespace Web_API_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductService productService) : ControllerBase
    {
       private readonly IProductService _productService= productService;
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductRequestDto dto)
        {
            await _productService.AddProductAsync(dto);
            return Ok(new
            {
                Message="Product added."
            });
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductAsync();
            return Ok(products);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return Ok(product);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductRequestDto dto)
        {
            var product = await _productService.GetProductByIdAsync(id);
            await _productService.UpdateProductAsync( id,dto);
            return Ok(new
            {
                Message="Product updated."
            });
        }
        [Authorize]
        [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok(new
            {
                Message = "Product deleted"
            });
        }
       
    }
}
