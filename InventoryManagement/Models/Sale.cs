using System;
using System.Collections.Generic;

namespace InventoryManagement.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public int CustomerId { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? CreatedByUserId { get; set; }

    public virtual User? CreatedByUser { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<SalesItem> SalesItems { get; set; } = new List<SalesItem>();
}
