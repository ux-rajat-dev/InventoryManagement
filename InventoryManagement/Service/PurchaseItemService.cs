using InventoryManagement.CommandModel;
using InventoryManagement.Interface;
using InventoryManagement.Models;
using InventoryManagement.QueryModel;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Service
{
    public class PurchaseItemService : IPurchaseItemService
    {
        private readonly InventoryDbContext _context;

        public PurchaseItemService(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<PurchaseItemQueryModel>> GetAllAsync()
        {
            return await _context.PurchaseItems
                .Include(pi => pi.Product)
                .Select(pi => new PurchaseItemQueryModel
                {
                    PurchaseItemId = pi.PurchaseItemId,
                    PurchaseId = pi.PurchaseId,
                    ProductName = pi.Product.Name,
                    Quantity = pi.Quantity,
                    UnitPrice = pi.UnitPrice
                }).ToListAsync();
        }

        public async Task<PurchaseItemQueryModel> GetByIdAsync(int id)
        {
            var item = await _context.PurchaseItems
                .Include(pi => pi.Product)
                .FirstOrDefaultAsync(pi => pi.PurchaseItemId == id);

            if (item == null) return null;

            return new PurchaseItemQueryModel
            {
                PurchaseItemId = item.PurchaseItemId,
                PurchaseId = item.PurchaseId,
                ProductName = item.Product.Name,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            };
        }

        public async Task<bool> CreateAsync(PurchaseItemCommandModel model)
        {
            var purchaseItem = new PurchaseItem
            {
                PurchaseId = model.PurchaseId,
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice
            };

            _context.PurchaseItems.Add(purchaseItem);

            // Optional: Increase stock for the product
            var product = await _context.Products.FindAsync(model.ProductId);
            if (product != null)
            {
                product.Quantity += model.Quantity;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, PurchaseItemCommandModel model)
        {
            var item = await _context.PurchaseItems.FindAsync(id);
            if (item == null) return false;

            // Optional: Adjust stock (remove old quantity, add new one)
            var product = await _context.Products.FindAsync(model.ProductId);
            if (product != null)
            {
                product.Quantity -= item.Quantity; // remove old
                product.Quantity += model.Quantity; // add new
            }

            item.PurchaseId = model.PurchaseId;
            item.ProductId = model.ProductId;
            item.Quantity = model.Quantity;
            item.UnitPrice = model.UnitPrice;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.PurchaseItems.FindAsync(id);
            if (item == null) return false;

            var product = await _context.Products.FindAsync(item.ProductId);
            if (product != null)
            {
                product.Quantity -= item.Quantity;
            }

            _context.PurchaseItems.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
