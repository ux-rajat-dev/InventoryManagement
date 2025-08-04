namespace InventoryManagement.QueryModel
{
    public class PurchaseQueryModel
    {
       
            public int PurchaseId { get; set; }

            public int SupplierId { get; set; }

            public string SupplierName { get; set; } = string.Empty; // For display

            public decimal TotalAmount { get; set; }

            public DateTime CreatedAt { get; set; }

            public int? CreatedByUserId { get; set; }

            public string? CreatedByUserName { get; set; } // For display

            public List<PurchaseItemQueryModel> PurchaseItems { get; set; } = new();
        }
    }


 
