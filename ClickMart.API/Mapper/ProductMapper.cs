using ClickMart.API.DTO;
using ClickMart.API.Models;

namespace ClickMart.API.Mapper
{
    public class ProductMapper
    {
        public ProductDTO ProductToDTO(Product product)
        {
            ProductDTO productDTO = new ProductDTO();
            productDTO.Name = product.Name;
            productDTO.Identifier = product.Identifier;
            productDTO.Price = product.Price;
            productDTO.Category = product.Category;
            productDTO.PublishDate = product.PublishDate;
            productDTO.Image = product.Image;
            productDTO.Description = product.Description;

            return productDTO;
        }

        public ProductDTO ProductToDTO(UpdateProduct updateProduct)
        {
            ProductDTO productDTO = new ProductDTO();
            productDTO.Name = updateProduct.Name ?? null;
            productDTO.Identifier = updateProduct.Identifier ?? throw new Exception ("Identifier can't be null");
            productDTO.Price = updateProduct.Price;
            productDTO.Category = updateProduct.Category;
            productDTO.PublishDate = updateProduct.PublishDate;
            productDTO.Image = updateProduct.Image;
            productDTO.Description = updateProduct.Description;

            return productDTO;
        }
    }
}
