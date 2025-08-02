using System;
using System.Collections.Generic;

namespace InventoryManagement.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();
}
