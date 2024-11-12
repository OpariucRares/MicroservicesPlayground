using Ecommerce.Services.ProductAPI.Models.Dto;
using Ecommerce.Services.ProductAPI.Models;

namespace Ecommerce.Services.ProductAPI.Mappers
{
    public interface IProductMapper
    {
        Product ToProduct(ProductDto productDto);
        void UpdateProduct(ProductDto productDto, Product product);
    }
}
