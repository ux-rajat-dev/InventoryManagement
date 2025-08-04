namespace InventoryManagement.QueryModel
{
    public class StockTransactionQueryModel
    { 
            public int TransactionId { get; set; }

            public int ProductId { get; set; }
            public string ProductName { get; set; } = string.Empty;

            public int Quantity { get; set; }

            public int TypeId { get; set; }
            public string TypeName { get; set; } = string.Empty;

            public DateTime CreatedAt { get; set; }

            public int? CreatedByUserId { get; set; }
            public string? CreatedByUserName { get; set; }
        }
    }
 
