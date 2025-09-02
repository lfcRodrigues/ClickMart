using ClickMart.API.DAO;
using ClickMart.API.DTO;

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

        public int UpdateProduct(ProductDTO dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("Product Id is required for update");

            if (dto.Price <= 0)
                throw new ArgumentException("Price must be greater than zero");

            return _dao.UpdateProduct(dto);
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
