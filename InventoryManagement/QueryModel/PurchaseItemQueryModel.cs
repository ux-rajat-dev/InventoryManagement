namespace InventoryManagement.QueryModel
{
    public class PurchaseItemQueryModel
    {
        public int PurchaseItemId { get; set; }
        public int PurchaseId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total => Quantity * UnitPrice;
    }
}
