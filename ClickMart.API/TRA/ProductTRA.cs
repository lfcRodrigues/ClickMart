using ClickMart.API.DAO;
using ClickMart.API.DTO;
using ClickMart.API.Enum;
using ClickMart.API.Models;
using Microsoft.Data.SqlClient;

namespace ClickMart.API.TRA
{
    public class ProductTRA
    {
        private readonly ProductDAO _dao = new();

        public int InsertProduct(ProductDTO productDTO)
        {
            // Regras de negócio poderiam ser aplicadas aqui (ex: validação de preço > 0)
            if (productDTO.Price <= 0)
                throw new ArgumentException("Price must be greater than zero");

            Product existingProduct = _dao.GetProductByIdentifier(productDTO.Identifier);

            if (!string.IsNullOrEmpty(existingProduct.Identifier))
                throw new ArgumentException("There is already a Product with that identifier.");

            if (!productDTO.Category.HasValue && System.Enum.IsDefined(typeof(Category), productDTO.Category.Value))
                throw new Exception("The value entered in the CAtegory field does not exist in the list.");

            return _dao.InsertProduct(productDTO);
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
                throw new ArgumentException("Product not found with the given identifier or it doesn't exist.");

            return _dao.UpdateProduct(productDTO);
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
