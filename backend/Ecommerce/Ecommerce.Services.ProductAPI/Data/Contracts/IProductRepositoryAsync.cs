using Ecommerce.Services.ProductAPI.Models;

namespace Ecommerce.Services.ProductAPI.Data.Contracts
{
    public interface IProductRepositoryAsync
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product newProduct);
        Task<bool> DeleteAsync(Product product);
    }
}
