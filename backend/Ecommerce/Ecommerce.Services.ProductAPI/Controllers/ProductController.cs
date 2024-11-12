using Ecommerce.Services.ProductAPI.Data.Contracts;
using Ecommerce.Services.ProductAPI.Mappers;
using Ecommerce.Services.ProductAPI.Models;
using Ecommerce.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepositoryAsync _productRepositoryAsync;
        private readonly IProductMapper _productMapper;

        public ProductController(IProductRepositoryAsync productRepositoryAsync, IProductMapper productMapper)
        {
            _productRepositoryAsync = productRepositoryAsync;
            _productMapper = productMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productRepositoryAsync.GetAllAsync();
                return Ok(ApiResponse<IEnumerable<Product>>.Successful(products, "Products retrieved successfully."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<IEnumerable<Product>>.Failure("An unexpected error occurred: " + ex.Message));
            }
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            try
            {
                var resultProduct = await _productRepositoryAsync.GetByIdAsync(id);
                if (resultProduct == null)
                {
                    return NotFound(ApiResponse<Product>.Failure("Product not found."));
                }
                return Ok(ApiResponse<Product>.Successful(resultProduct, "Product retrieved successfully."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<Product>.Failure("An unexpected error occurred: " + ex.Message));
            }
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            try
            {
                var productToCreate = _productMapper.ToProduct(productDto);
                var createdProduct = await _productRepositoryAsync.CreateAsync(productToCreate);

                return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, ApiResponse<Product>.Successful(createdProduct, "Product added successfully."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<Product>.Failure("An unexpected error occurred: " + ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductDto productDto)
        {
            try
            {
                var existingProduct = await _productRepositoryAsync.GetByIdAsync(id);
                if (existingProduct == null)
                {
                    return NotFound(ApiResponse<Product>.Failure("Product not found."));
                }

                _productMapper.UpdateProduct(productDto, existingProduct);

                var result = await _productRepositoryAsync.UpdateAsync(existingProduct);

                return Ok(ApiResponse<Product>.Successful(result, "Product updated successfully."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<Product>.Failure("An unexpected error occurred: " + ex.Message));
            }
            
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                var product = await _productRepositoryAsync.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound(ApiResponse<Product>.Failure("Product not found."));
                }
                await _productRepositoryAsync.DeleteAsync(product);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<Product>.Failure("An unexpected error occurred: " + ex.Message));
            }
        }
    }
}
