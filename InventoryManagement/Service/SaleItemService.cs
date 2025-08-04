 
using InventoryManagement.CommandModel;
using InventoryManagement.Interface;
using InventoryManagement.Models;
using InventoryManagement.QueryModel;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Services
{
    public class SalesItemService : ISaleItemService
    {
        private readonly InventoryDbContext _context;
       

        public SalesItemService(InventoryDbContext context)
        {
            _context = context;
        }

        public void Add(SaleItemCommandModel item)
        {
            var newItem = new SalesItem
            {
                SaleId = item.SaleId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                TotalPrice = item.Quantity * item.UnitPrice // Auto-calculated
            };

            _context.SalesItems.Add(newItem);
            _context.SaveChanges();
        }

        public void Update(int salesItemId, SaleItemCommandModel item)
        {
            var existing = _context.SalesItems.FirstOrDefault(s => s.SalesItemId == salesItemId);
            if (existing == null) return;

            existing.SaleId = item.SaleId;
            existing.ProductId = item.ProductId;
            existing.Quantity = item.Quantity;
            existing.UnitPrice = item.UnitPrice;
            existing.TotalPrice = item.Quantity * item.UnitPrice; // Auto-calculated

            _context.SaveChanges();
        }


        public void Remove(int salesItemId)
        {
            var item = _context.SalesItems.FirstOrDefault(s => s.SalesItemId == salesItemId);
            if (item == null) return;

            _context.SalesItems.Remove(item);
            _context.SaveChanges();
        }

        public SalesItemQueryModel Get(int salesItemId)
        {
            var item = _context.SalesItems
                .Include(s => s.Product)
                .FirstOrDefault(s => s.SalesItemId == salesItemId);

            if (item == null) return null!;

            return new SalesItemQueryModel
            {
                SalesItemId = item.SalesItemId,
                SaleId = item.SaleId,
                ProductId = item.ProductId,
                ProductName = item.Product.Name,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                TotalPrice = item.TotalPrice
            };
        }

        public List<SalesItemQueryModel> GetAll()
        {
            return _context.SalesItems
                .Include(s => s.Product)
                .Select(item => new SalesItemQueryModel
                {
                    SalesItemId = item.SalesItemId,
                    SaleId = item.SaleId,
                    ProductId = item.ProductId,
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalPrice = item.TotalPrice
                }).ToList();
        }
    }
}
