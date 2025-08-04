using InventoryManagement.CommandModel;
using InventoryManagement.Interface;
using InventoryManagement.Models;
using InventoryManagement.QueryModel;
using Microsoft.AspNetCore.Mvc;

 
         

namespace InventoryManagement.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class PurchaseController : ControllerBase
        {
            private readonly IPurchaseService _purchaseService;

            public PurchaseController(IPurchaseService purchaseService)
            {
                _purchaseService = purchaseService;
            }

            [HttpPost]
            public IActionResult Add([FromBody] PurchaseCommandModel model)
            {
                _purchaseService.Add(model);
                return Ok(new { message = "Purchase added successfully" });
            }

            [HttpPut("{id}")]
            public IActionResult Update(int id, [FromBody] PurchaseCommandModel model)
            {
                _purchaseService.Update(id, model);
                return Ok(new { message = "Purchase updated successfully" });
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
            _purchaseService.Remove(id);
            return Ok(new { message = "Purchase deleted successfully" });
        }

        [HttpGet("{id}")]
        public ActionResult<PurchaseQueryModel> Get(int id)
        {
            var result = _purchaseService.GetPurchase(id);
            if (result == null)
                return NotFound(new { message = "Purchase not found" });

            return Ok(result);
        }

        [HttpGet]
        public ActionResult<List<PurchaseQueryModel>> GetAll()
        {
            return Ok(_purchaseService.GetAllPurchases());
        }
    }
}
