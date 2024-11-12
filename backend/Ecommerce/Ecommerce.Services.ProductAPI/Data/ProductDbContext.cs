using Ecommerce.Services.ProductAPI.Data.Contracts;
using Ecommerce.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Services.ProductAPI.Data
{
    public class ProductDbContext : DbContext, IProductDbContext
    {
        private readonly DbContextOptions<ProductDbContext> _options;
        private readonly IConfiguration _configuration;
        public DbSet<Product> Products { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext> options, IConfiguration configuration) : base(options)
        {
            _options = options;
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = Guid.NewGuid(), Name = "Product X", Price = 9.99m, Stock = 100 },
                new Product { Id = Guid.NewGuid(), Name = "Product Y", Price = 19.99m, Stock = 50 },
                new Product { Id = Guid.NewGuid(), Name = "Product Z", Price = 29.99m, Stock = 25 }
            );
            base.OnModelCreating(modelBuilder);
        }

        public Task SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
