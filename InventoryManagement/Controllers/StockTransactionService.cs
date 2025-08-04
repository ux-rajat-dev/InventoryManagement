using InventoryManagement.CommandModel;
using InventoryManagement.Interface;
using InventoryManagement.Models;
using InventoryManagement.QueryModel;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockTransactionController : ControllerBase
    {
        private readonly IStockTransactionService _service;

        public StockTransactionController(IStockTransactionService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] StockTransactionCommandModel model)
        {
            _service.Add(model);
            return Ok("Stock transaction added successfully.");
        }

        [HttpDelete("remove/{transactionId}")]
        public IActionResult Remove(int transactionId)
        {
            _service.Remove(transactionId);
            return Ok("Stock transaction removed successfully.");
        }

        [HttpGet("get-all")]
        public ActionResult<List<StockTransactionQueryModel>> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("get/{transactionId}")]
        public ActionResult<StockTransactionQueryModel> GetById(int transactionId)
        {
            var result = _service.GetById(transactionId);
            if (result == null)
                return NotFound("Transaction not found.");
            return result;
        }
    }
}
