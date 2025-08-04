namespace InventoryManagement.CommandModel
{
    public class StockTransactionCommandModel
    { 
            public int TransactionId { get; set; }

            public int ProductId { get; set; }

            public int Quantity { get; set; }

            public int TypeId { get; set; }

            public DateTime CreatedAt { get; set; }

            public int? CreatedByUserId { get; set; }
        }
    }

 