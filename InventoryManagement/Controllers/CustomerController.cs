using InventoryManagement.CommandModel;
using InventoryManagement.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _service.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerCommandModel model)
        {
            var result = await _service.CreateAsync(model);
            return result ? Ok("Customer created") : BadRequest("Creation failed");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerCommandModel model)
        {
            var result = await _service.UpdateAsync(id, model);
            return result ? Ok("Customer updated") : NotFound("Customer not found");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? Ok("Customer deleted") : NotFound("Customer not found");
        }
    }
}
