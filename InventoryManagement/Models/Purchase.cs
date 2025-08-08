using System;
using System.Collections.Generic;

namespace InventoryManagement.Models;

public partial class Purchase
{
    public int PurchaseId { get; set; }

    public int SupplierId { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedByUserId { get; set; }

    public virtual User? CreatedByUser { get; set; }

    public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

    public virtual Supplier Supplier { get; set; } = null!;
}
