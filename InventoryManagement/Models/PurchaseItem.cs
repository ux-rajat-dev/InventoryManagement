﻿using System;
using System.Collections.Generic;

namespace InventoryManagement.Models;

public partial class PurchaseItem
{
    public int PurchaseItemId { get; set; }

    public int PurchaseId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Purchase Purchase { get; set; } = null!;
}
