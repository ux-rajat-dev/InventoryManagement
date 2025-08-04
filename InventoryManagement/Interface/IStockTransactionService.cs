using InventoryManagement.CommandModel;
using InventoryManagement.QueryModel;

namespace InventoryManagement.Interface
{
    public interface IStockTransactionService
    { 
            void Add(StockTransactionCommandModel model);
            void Remove(int transactionId);
            List<StockTransactionQueryModel> GetAll();
            StockTransactionQueryModel? GetById(int transactionId);
        }
    }
 
