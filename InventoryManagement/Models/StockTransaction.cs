using System;
using System.Collections.Generic;

namespace InventoryManagement.Models;

public partial class StockTransaction
{
    public int TransactionId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public int TypeId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedByUserId { get; set; }

    public virtual User? CreatedByUser { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual StockTransactionType Type { get; set; } = null!;
}
