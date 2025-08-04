namespace InventoryManagement.CommandModel
{
    public class PurchaseCommandModel
    { 
            public int SupplierId { get; set; }

            public decimal TotalAmount { get; set; }

            public DateTime CreatedAt { get; set; }

            public int? CreatedByUserId { get; set; }

            public List<PurchaseItemCommandModel>? PurchaseItems { get; set; }
        }
    }

 
