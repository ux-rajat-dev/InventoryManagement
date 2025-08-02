using InventoryManagement.CommandModel;
using InventoryManagement.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseItemController : ControllerBase
    {
        private readonly IPurchaseItemService _service;

        public PurchaseItemController(IPurchaseItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PurchaseItemCommandModel model)
        {
            var result = await _service.CreateAsync(model);
            return result ? Ok("Purchase item created") : BadRequest("Creation failed");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PurchaseItemCommandModel model)
        {
            var result = await _service.UpdateAsync(id, model);
            return result ? Ok("Purchase item updated") : NotFound("Item not found");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? Ok("Purchase item deleted") : NotFound("Item not found");
        }
    }
}
