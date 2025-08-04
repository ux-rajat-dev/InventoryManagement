using InventoryManagement.CommandModel;
using InventoryManagement.QueryModel;

namespace InventoryManagement.Interface
{
    public interface IStockTransactionTypeService
    {
        
            void Add(StockTransactionTypeCommandModel model);
            void Update(int id, StockTransactionTypeCommandModel model);
            void Delete(int id);
            List<StockTransactionTypeQueryModel> GetAll();
            StockTransactionTypeQueryModel? GetById(int id);
        }
    }

 