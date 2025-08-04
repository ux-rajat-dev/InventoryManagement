using InventoryManagement.CommandModel;
 
using InventoryManagement.Interface;
using InventoryManagement.QueryModel;
 
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] SaleCommandModel model)
        {
            _saleService.Add(model);
            return Ok(new { message = "Sale added successfully" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SaleCommandModel model)
        {
            _saleService.Update(id, model);
            return Ok(new { message = "Sale updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _saleService.Remove(id);
            return Ok(new { message = "Sale deleted successfully" });
        }

        [HttpGet("{id}")]
        public ActionResult<SaleQueryModel> Get(int id)
        {
            var result = _saleService.GetSale(id);
            if (result == null)
                return NotFound(new { message = "Sale not found" });

            return Ok(result);
        }

        [HttpGet]
        public ActionResult<List<SaleQueryModel>> GetAll()
        {
            return Ok(_saleService.GetAllSales());
        }
    }
}
