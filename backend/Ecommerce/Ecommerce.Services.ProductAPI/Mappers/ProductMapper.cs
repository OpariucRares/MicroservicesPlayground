using Ecommerce.Services.ProductAPI.Models.Dto;
using Ecommerce.Services.ProductAPI.Models;

namespace Ecommerce.Services.ProductAPI.Mappers
{
    public class ProductMapper : IProductMapper
    {
        public Product ToProduct(ProductDto productDto)
        {
            if (productDto == null) throw new ArgumentNullException(nameof(productDto));

            return new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock
            };
        }

        public void UpdateProduct(ProductDto productDto, Product product)
        {
            if (!string.IsNullOrEmpty(productDto.Name))
            {
                product.Name = productDto.Name;
            }
            product.Price = productDto.Price;
            product.Stock = productDto.Stock;
        }
    }
}
