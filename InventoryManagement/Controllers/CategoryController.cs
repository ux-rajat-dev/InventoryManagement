using InventoryManagement.CommandModel;
using InventoryManagement.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
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
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCommandModel model)
        {
            var result = await _service.CreateAsync(model);
            return result ? Ok("Category created") : BadRequest("Failed to create category");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryCommandModel model)
        {
            var result = await _service.UpdateAsync(id, model);
            return result ? Ok("Category updated") : NotFound("Category not found");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? Ok("Category deleted") : NotFound("Category not found");
        }
    }
}
