using ClickMart.API.DAO;
using ClickMart.API.DTO;
using ClickMart.API.Models;

namespace ClickMart.API.TRA
{
    public class ProductTRA
    {
        private readonly ProductDAO _dao = new();

        public int InsertProduct(ProductDTO dto)
        {
            // Regras de negócio poderiam ser aplicadas aqui (ex: validação de preço > 0)
            if (dto.Price <= 0)
                throw new ArgumentException("Price must be greater than zero");

            return _dao.InsertProduct(dto);
        }

        public List<ProductDTO> GetAllProducts()
        {
            return _dao.GetAllProducts();
        }

        public int UpdateProduct(ProductDTO productDTO)
        {
            // Verifica se o produto existe usando o identificador
            Product existingProduct = _dao.GetProductByIdentifier(productDTO.Identifier);
            if (existingProduct == null)
                throw new ArgumentException("Product not found with the given identifier.");

            if (string.IsNullOrWhiteSpace(productDTO.Identifier))
                throw new ArgumentException("Identifier must be sent.");

            // Atualiza os dados do produto existente
            existingProduct.Name = productDTO.Name;
            existingProduct.PublishDate = productDTO.PublishDate;

            return _dao.UpdateProduct(existingProduct);
        }

        public int DeleteProduct(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Product Id is required for delete");

            return _dao.DeleteProduct(id);
        }

        public int DeleteProduct(string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                throw new ArgumentException("Identifier is required for delete");

            return _dao.DeleteProductByIdentifier(identifier);
        }

    }
}
