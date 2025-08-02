using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Interface;
using InventoryManagement.CommandModel;

namespace InventoryManagement.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _service;

        public SupplierController(ISupplierService service)
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
        public async Task<IActionResult> Create([FromBody] SupplierCommandModel model)
        {
            var result = await _service.CreateAsync(model);
            return result ? Ok("Supplier created") : BadRequest("Failed to create supplier");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SupplierCommandModel model)
        {
            var result = await _service.UpdateAsync(id, model);
            return result ? Ok("Supplier updated") : NotFound("Supplier not found");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? Ok("Supplier deleted") : NotFound("Supplier not found");
        }
    }
}
