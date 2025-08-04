using InventoryManagement.CommandModel;
using InventoryManagement.Interface;
using InventoryManagement.Models;
using InventoryManagement.QueryModel;
using Microsoft.EntityFrameworkCore;
namespace InventoryManagement.Service
{
  
 
        public class PurchaseService : IPurchaseService
        {
            private readonly InventoryDbContext _context;

            public PurchaseService(InventoryDbContext context)
            {
                _context = context;
            }

            public void Add(PurchaseCommandModel purchase)
            {
                var newPurchase = new Purchase
                {
                    SupplierId = purchase.SupplierId,
                    TotalAmount = purchase.TotalAmount,
                    CreatedAt = purchase.CreatedAt,
                    CreatedByUserId = purchase.CreatedByUserId,
                    PurchaseItems = purchase.PurchaseItems?.Select(item => new PurchaseItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    }).ToList() ?? new List<PurchaseItem>()
                };

                _context.Purchases.Add(newPurchase);
                _context.SaveChanges();
            }

            public void Update(int purchaseId, PurchaseCommandModel purchase)
            {
                var existingPurchase = _context.Purchases
                    .Include(p => p.PurchaseItems)
                    .FirstOrDefault(p => p.PurchaseId == purchaseId);

                if (existingPurchase == null) return;

                existingPurchase.SupplierId = purchase.SupplierId;
                existingPurchase.TotalAmount = purchase.TotalAmount;
                existingPurchase.CreatedAt = purchase.CreatedAt;
                existingPurchase.CreatedByUserId = purchase.CreatedByUserId;

                // Clear old items and replace with updated ones
                existingPurchase.PurchaseItems.Clear();
                if (purchase.PurchaseItems != null)
                {
                    foreach (var item in purchase.PurchaseItems)
                    {
                        existingPurchase.PurchaseItems.Add(new PurchaseItem
                        {
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrice,
                        });
                    }
                }

                _context.SaveChanges();
            }

            public void Remove(int purchaseId)
            {
                var purchase = _context.Purchases.FirstOrDefault(p => p.PurchaseId == purchaseId);
                if (purchase == null) return;

                _context.Purchases.Remove(purchase);
                _context.SaveChanges();
            }

            public PurchaseQueryModel GetPurchase(int purchaseId)
            {
                var purchase = _context.Purchases
                    .Include(p => p.Supplier)
                    .Include(p => p.CreatedByUser)
                    .Include(p => p.PurchaseItems)
                    .FirstOrDefault(p => p.PurchaseId == purchaseId);

                if (purchase == null) return null!;

                return new PurchaseQueryModel
                {
                    PurchaseId = purchase.PurchaseId,
                    SupplierId = purchase.SupplierId,
                    SupplierName = purchase.Supplier.Name,
                    TotalAmount = purchase.TotalAmount,
                    CreatedAt = purchase.CreatedAt,
                    CreatedByUserId = purchase.CreatedByUserId,
                    CreatedByUserName = purchase.CreatedByUser?.FullName,
                    PurchaseItems = purchase.PurchaseItems.Select(item => new PurchaseItemQueryModel
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    }).ToList()
                };
            }

            public List<PurchaseQueryModel> GetAllPurchases()
            {
                return _context.Purchases
                    .Include(p => p.Supplier)
                    .Include(p => p.CreatedByUser)
                    .Include(p => p.PurchaseItems)
                    .Select(purchase => new PurchaseQueryModel
                    {
                        PurchaseId = purchase.PurchaseId,
                        SupplierId = purchase.SupplierId,
                        SupplierName = purchase.Supplier.Name,
                        TotalAmount = purchase.TotalAmount,
                        CreatedAt = purchase.CreatedAt,
                        CreatedByUserId = purchase.CreatedByUserId,
                        CreatedByUserName = purchase.CreatedByUser.FullName,
                        PurchaseItems = purchase.PurchaseItems.Select(item => new PurchaseItemQueryModel
                        {
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrice
                        }).ToList()
                    }).ToList();
            }
        }
    }

