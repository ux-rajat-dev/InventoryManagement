
using InventoryManagement.CommandModel;
using InventoryManagement.Interface;
using InventoryManagement.Models;
using InventoryManagement.QueryModel;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Services
{
    public class SaleService : ISaleService
    {
        private readonly InventoryDbContext _context;

        public SaleService(InventoryDbContext context)
        {
            _context = context;
        }

        public void Add(SaleCommandModel sale)
        {
            var newSale = new Sale
            {
                CustomerId = sale.CustomerId,
                TotalAmount = sale.TotalAmount,
                CreatedAt = sale.CreatedAt,
                CreatedByUserId = sale.CreatedByUserId,
                SalesItems = sale.SalesItems?.Select(item => new SalesItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                }).ToList() ?? new List<SalesItem>()
            };

            _context.Sales.Add(newSale);
            _context.SaveChanges();
        }

        public void Update(int saleId, SaleCommandModel sale)
        {
            var existingSale = _context.Sales
                .Include(s => s.SalesItems)
                .FirstOrDefault(s => s.SaleId == saleId);

            if (existingSale == null) return;

            existingSale.CustomerId = sale.CustomerId;
            existingSale.TotalAmount = sale.TotalAmount;
            existingSale.CreatedAt = sale.CreatedAt;
            existingSale.CreatedByUserId = sale.CreatedByUserId;

            // Clear existing items and add updated ones
            existingSale.SalesItems.Clear();
            if (sale.SalesItems != null)
            {
                foreach (var item in sale.SalesItems)
                {
                    existingSale.SalesItems.Add(new SalesItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    });
                }
            }

            _context.SaveChanges();
        }

        public void Remove(int saleId)
        {
            var sale = _context.Sales.FirstOrDefault(s => s.SaleId == saleId);
            if (sale == null) return;

            _context.Sales.Remove(sale);
            _context.SaveChanges();
        }

        public SaleQueryModel GetSale(int saleId)
        {
            var sale = _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.CreatedByUser)
                .Include(s => s.SalesItems)
                .FirstOrDefault(s => s.SaleId == saleId);

            if (sale == null) return null!;

            return new SaleQueryModel
            {
                SaleId = sale.SaleId,
                CustomerId = sale.CustomerId,
                CustomerName = sale.Customer.FullName,
                TotalAmount = sale.TotalAmount,
                CreatedAt = sale.CreatedAt,
                CreatedByUserId = sale.CreatedByUserId,
                CreatedByUserName = sale.CreatedByUser?.FullName,
                SalesItems = sale.SalesItems.Select(item => new SalesItemQueryModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                }).ToList()
            };
        }

        public List<SaleQueryModel> GetAllSales()
        {
            return _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.CreatedByUser)
                .Include(s => s.SalesItems)
                .Select(sale => new SaleQueryModel
                {
                    SaleId = sale.SaleId,
                    CustomerId = sale.CustomerId,
                    CustomerName = sale.Customer.FullName,
                    TotalAmount = sale.TotalAmount,
                    CreatedAt = sale.CreatedAt,
                    CreatedByUserId = sale.CreatedByUserId,
                    CreatedByUserName = sale.CreatedByUser.FullName,
                    SalesItems = sale.SalesItems.Select(item => new SalesItemQueryModel
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    }).ToList()
                }).ToList();
        }
    }
}
