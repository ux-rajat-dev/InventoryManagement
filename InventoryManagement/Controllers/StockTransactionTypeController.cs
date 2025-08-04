using InventoryManagement.CommandModel;
using InventoryManagement.Interface;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockTransactionTypeController : ControllerBase
    {
        private readonly IStockTransactionTypeService _service;

        public StockTransactionTypeController(IStockTransactionTypeService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add([FromBody] StockTransactionTypeCommandModel model)
        {
            _service.Add(model);
            return Ok("Transaction type added");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] StockTransactionTypeCommandModel model)
        {
            _service.Update(id, model);
            return Ok("Transaction type updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Transaction type deleted");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
