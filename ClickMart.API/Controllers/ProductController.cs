using Microsoft.AspNetCore.Mvc;
using ClickMart.API.DTO;
using ClickMart.API.TRA;

namespace ClickMart.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductTRA _tra = new();

        [HttpPost("insert")]
        public IActionResult Insert(ProductDTO dto)
        {
            try
            {
                var result = _tra.InsertProduct(dto);
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
    }
}
