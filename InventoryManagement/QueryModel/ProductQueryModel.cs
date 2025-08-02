namespace InventoryManagement.QueryModel
{
    public class ProductQueryModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
