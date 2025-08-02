using InventoryManagement.CommandModel;
using InventoryManagement.Interface;
using InventoryManagement.Models;
using InventoryManagement.QueryModel;
using Microsoft.EntityFrameworkCore;

namespace YourNamespace.Service
{
    public class ProductService : IProductService
    {
        private readonly InventoryDbContext _context;

        public ProductService(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductQueryModel>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Select(p => new ProductQueryModel
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    SKU = p.Sku,
                    CategoryName = p.Category != null ? p.Category.Name : "N/A",
                    SupplierName = p.Supplier != null ? p.Supplier.Name : "N/A",
                    UnitPrice = p.UnitPrice,
                    Quantity = p.Quantity,
                    CreatedAt = p.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<ProductQueryModel> GetByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null) return null;

            return new ProductQueryModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                SKU = product.Sku,
                CategoryName = product.Category?.Name ?? "N/A",
                SupplierName = product.Supplier?.Name ?? "N/A",
                UnitPrice = product.UnitPrice,
                Quantity = product.Quantity,
                CreatedAt = product.CreatedAt
            };
        }

        public async Task<bool> CreateAsync(ProductCommandModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Sku = model.SKU,
                CategoryId = model.CategoryId,
                SupplierId = model.SupplierId,
                UnitPrice = model.UnitPrice,
                Quantity = model.Quantity,
                CreatedAt = DateTime.UtcNow
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, ProductCommandModel model)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            product.Name = model.Name;
            product.Sku = model.SKU;
            product.CategoryId = model.CategoryId;
            product.SupplierId = model.SupplierId;
            product.UnitPrice = model.UnitPrice;
            product.Quantity = model.Quantity;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
