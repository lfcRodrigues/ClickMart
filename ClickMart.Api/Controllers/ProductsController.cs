using ClickMart.Api.Data;
using ClickMart.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClickMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDAO _dao;

        public ProductsController(ProductDAO dao)
        {
            _dao = dao;
        }

        [HttpPost("GetAll")]
        public IActionResult GetAllProducts()
        {
            return Ok(_dao.GetAll());
        }

        [HttpPost("GetById")]
        public IActionResult GetProductById(int id)
        {
            var product = _dao.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost("Create")]
        public IActionResult CreateProduct(Product product)
        {
            _dao.Create(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id) return BadRequest();
            _dao.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _dao.Delete(id);
            return NoContent();
        }
    }
}
