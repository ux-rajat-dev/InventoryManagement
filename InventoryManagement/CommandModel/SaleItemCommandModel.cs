namespace InventoryManagement.CommandModel
{
    public class SaleItemCommandModel
    {
         
            public int SaleId { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal TotalPrice { get; set; }
        }
    }

 
