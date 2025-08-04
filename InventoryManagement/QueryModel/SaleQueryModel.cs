namespace InventoryManagement.QueryModel
{
    public class SaleQueryModel
    {
            public int SaleId { get; set; }

            public int CustomerId { get; set; }

            public string CustomerName { get; set; } = string.Empty; // Optional for display

            public decimal TotalAmount { get; set; }

            public DateTime CreatedAt { get; set; }

            public int? CreatedByUserId { get; set; }

            public string? CreatedByUserName { get; set; } // Optional for display

            public List<SalesItemQueryModel> SalesItems { get; set; } = new();
        }
    }

 
