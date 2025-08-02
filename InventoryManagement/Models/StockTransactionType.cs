using System;
using System.Collections.Generic;

namespace InventoryManagement.Models;

public partial class StockTransactionType
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();
}
