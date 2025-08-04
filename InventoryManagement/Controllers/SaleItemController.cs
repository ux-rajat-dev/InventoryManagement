 
using InventoryManagement.CommandModel;
using InventoryManagement.Interface;
using InventoryManagement.QueryModel;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesItemController : ControllerBase
    {
        private readonly ISaleItemService _salesItemService;

        public SalesItemController(ISaleItemService salesItemService)
        {
            _salesItemService = salesItemService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] SaleItemCommandModel model)
        {
            _salesItemService.Add(model);
            return Ok(new { message = "Sales item added successfully" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SaleItemCommandModel model)
        {
            _salesItemService.Update(id, model);
            return Ok(new { message = "Sales item updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _salesItemService.Remove(id);
            return Ok(new { message = "Sales item deleted successfully" });
        }

        [HttpGet("{id}")]
        public ActionResult<SalesItemQueryModel> Get(int id)
        {
            var result = _salesItemService.Get(id);
            if (result == null)
                return NotFound(new { message = "Sales item not found" });

            return Ok(result);
        }

        [HttpGet]
        public ActionResult<List<SalesItemQueryModel>> GetAll()
        {
            return Ok(_salesItemService.GetAll());
        }
    }
}
