using InventoryManagement.CommandModel;
using InventoryManagement.Interface;
using InventoryManagement.Models;
using InventoryManagement.QueryModel;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Services
{
    public class StockTransactionService : IStockTransactionService
    {
        private readonly InventoryDbContext _context;

        public StockTransactionService(InventoryDbContext context)
        {
            _context = context;
        }

        public void Add(StockTransactionCommandModel model)
        {
            var stockTransaction = new StockTransaction
            {
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                TypeId = model.TypeId,
                CreatedAt = model.CreatedAt,
                CreatedByUserId = model.CreatedByUserId
            };

            _context.StockTransactions.Add(stockTransaction);
            _context.SaveChanges();
        }

        public void Remove(int transactionId)
        {
            var stockTransaction = _context.StockTransactions.Find(transactionId);
            if (stockTransaction != null)
            {
                _context.StockTransactions.Remove(stockTransaction);
                _context.SaveChanges();
            }
        }

        public List<StockTransactionQueryModel> GetAll()
        {
            return _context.StockTransactions
                .Include(s => s.Product)
                .Include(s => s.Type)
                .Include(s => s.CreatedByUser)
                .Select(s => new StockTransactionQueryModel
                {
                    TransactionId = s.TransactionId,
                    ProductId = s.ProductId,
                    ProductName = s.Product.Name,
                    Quantity = s.Quantity,
                    TypeId = s.TypeId,
                    TypeName = s.Type.TypeName,
                    CreatedAt = s.CreatedAt,
                    CreatedByUserId = s.CreatedByUserId,
                    CreatedByUserName = s.CreatedByUser != null ? s.CreatedByUser.FullName : null
                })
                .ToList();
        }

        public StockTransactionQueryModel? GetById(int transactionId)
        {
            var s = _context.StockTransactions
                .Include(x => x.Product)
                .Include(x => x.Type)
                .Include(x => x.CreatedByUser)
                .FirstOrDefault(x => x.TransactionId == transactionId);

            if (s == null) return null;

            return new StockTransactionQueryModel
            {
                TransactionId = s.TransactionId,
                ProductId = s.ProductId,
                ProductName = s.Product.Name,
                Quantity = s.Quantity,
                TypeId = s.TypeId,
                TypeName = s.Type.TypeName,
                CreatedAt = s.CreatedAt,
                CreatedByUserId = s.CreatedByUserId,
                CreatedByUserName = s.CreatedByUser != null ? s.CreatedByUser.FullName : null
            };
        }
    }
}
