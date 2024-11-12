using Ecommerce.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.ProductAPI.Data.Contracts
{
    public interface IProductDbContext
    {
        DbSet<Product> Products { get; set; }
        Task SaveChangesAsync();
    }
}
