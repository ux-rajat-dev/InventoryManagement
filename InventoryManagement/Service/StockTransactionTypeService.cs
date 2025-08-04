using InventoryManagement.CommandModel;
using InventoryManagement.Models;
using InventoryManagement.QueryModel;
using InventoryManagement.Interface;

namespace InventoryManagement.Services
{
    public class StockTransactionTypeService : IStockTransactionTypeService
    {
        private readonly InventoryDbContext _context;

        public StockTransactionTypeService(InventoryDbContext context)
        {
            _context = context;
        }

        public void Add(StockTransactionTypeCommandModel model)
        {
            var type = new StockTransactionType
            {
                TypeName = model.TypeName
            };
            _context.StockTransactionTypes.Add(type);
            _context.SaveChanges();
        }

        public void Update(int id, StockTransactionTypeCommandModel model)
        {
            var type = _context.StockTransactionTypes.Find(id);
            if (type != null)
            {
                type.TypeName = model.TypeName;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var type = _context.StockTransactionTypes.Find(id);
            if (type != null)
            {
                _context.StockTransactionTypes.Remove(type);
                _context.SaveChanges();
            }
        }

        public List<StockTransactionTypeQueryModel> GetAll()
        {
            return _context.StockTransactionTypes
                .Select(x => new StockTransactionTypeQueryModel
                {
                    TypeId = x.TypeId,
                    TypeName = x.TypeName
                })
                .ToList();
        }

        public StockTransactionTypeQueryModel? GetById(int id)
        {
            return _context.StockTransactionTypes
                .Where(x => x.TypeId == id)
                .Select(x => new StockTransactionTypeQueryModel
                {
                    TypeId = x.TypeId,
                    TypeName = x.TypeName
                })
                .FirstOrDefault();
        }
    }
}
