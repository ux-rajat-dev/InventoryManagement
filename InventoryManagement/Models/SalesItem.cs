using System;
using System.Collections.Generic;

namespace InventoryManagement.Models;

public partial class SalesItem
{
    public int SalesItemId { get; set; }

    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Sale Sale { get; set; } = null!;
}
