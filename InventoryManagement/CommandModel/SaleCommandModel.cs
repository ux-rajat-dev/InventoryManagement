namespace InventoryManagement.CommandModel
{
    public class SaleCommandModel
    { 
            public int CustomerId { get; set; }

            public decimal TotalAmount { get; set; }

            public DateTime CreatedAt { get; set; }

            public int? CreatedByUserId { get; set; }

            public List<SaleItemCommandModel>? SalesItems { get; set; }
       
    }
   
}



