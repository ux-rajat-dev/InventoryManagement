using InventoryManagement.CommandModel;
using InventoryManagement.QueryModel;

namespace InventoryManagement.Interface
{
    public interface ISaleItemService
    { 
            void Add(SaleItemCommandModel item);
            void Update(int salesItemId, SaleItemCommandModel item);
            void Remove(int salesItemId);
            SalesItemQueryModel Get(int salesItemId);
            List<SalesItemQueryModel> GetAll();
        }
    }
 
