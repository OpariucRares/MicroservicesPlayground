using Ecommerce.Services.ProductAPI.Data.Contracts;
using Ecommerce.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.ProductAPI.Data
{
    public class ProductRepositoryAsync : IProductRepositoryAsync
    {
        private readonly IProductDbContext _productDbContext;

        public ProductRepositoryAsync(IProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productDbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _productDbContext.Products.FindAsync(id);
        }
        public async Task<Product> CreateAsync(Product product)
        {
            await _productDbContext.Products.AddAsync(product);
            await _productDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product newProduct)
        {
            _productDbContext.Products.Update(newProduct);
            await _productDbContext.SaveChangesAsync();
            return newProduct;
        }

        public async Task<bool> DeleteAsync(Product product)
        {
            _productDbContext.Products.Remove(product);
            await _productDbContext.SaveChangesAsync();
            return true;
        }
    }
}