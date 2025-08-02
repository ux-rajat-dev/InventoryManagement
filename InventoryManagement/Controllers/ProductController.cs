using InventoryManagement.CommandModel;
using InventoryManagement.Interface;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCommandModel model)
        {
            var result = await _service.CreateAsync(model);
            return result ? Ok("Product created") : BadRequest("Failed to create product");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductCommandModel model)
        {
            var result = await _service.UpdateAsync(id, model);
            return result ? Ok("Product updated") : NotFound("Product not found");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? Ok("Product deleted") : NotFound("Product not found");
        }
    }
}
