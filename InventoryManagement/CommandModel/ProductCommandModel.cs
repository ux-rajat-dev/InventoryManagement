namespace InventoryManagement.CommandModel
{
    public class ProductCommandModel
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }

}
