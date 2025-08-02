namespace InventoryManagement.CommandModel
{
    public class PurchaseItemCommandModel
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
