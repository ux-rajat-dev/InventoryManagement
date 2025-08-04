namespace InventoryManagement.QueryModel
{
  
        public class SalesItemQueryModel
        {
            public int SalesItemId { get; set; }
            public int SaleId { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; } = string.Empty;
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal TotalPrice { get; set; }
        }
    }

 