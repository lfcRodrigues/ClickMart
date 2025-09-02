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
    }
}
