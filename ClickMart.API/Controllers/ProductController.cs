using Microsoft.AspNetCore.Mvc;
using ClickMart.API.DTO;
using ClickMart.API.TRA;
using ClickMart.API.Mapper;
using ClickMart.API.Models;

namespace ClickMart.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductTRA _tra = new();
        public string Identifier { get; set; } = string.Empty;
        ProductMapper map = new ProductMapper();

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] Product product)
        {
            
            try
            {
                ProductDTO productDTO = map.ProductToDTO(product);
                var result = _tra.InsertProduct(productDTO);
                return Ok(new { success = true, rowsAffected = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost("getAll")]
        public IActionResult GetAll()
        {
            var products = _tra.GetAllProducts();
            return Ok(products);
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] UpdateProduct updateProduct)
        {
            try
            {
                ProductDTO productDTO = map.ProductToDTO(updateProduct);
                var result = _tra.UpdateProduct(productDTO);
                return Ok(new { success = true, rowsAffected = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Update Fail" });
            }
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _tra.DeleteProduct(id);
                return Ok(new { success = true, rowsAffected = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        // ✅ DTO específico para Delete
        public class DeleteProductRequest
        {
            public string Identifier { get; set; } = string.Empty;
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] DeleteProductRequest request)
        {
            try
            {
                var result = _tra.DeleteProduct(request.Identifier);
                return Ok(new { success = true, message = $"The product with identifier '{request.Identifier}' was successfully deleted." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

    }
}
