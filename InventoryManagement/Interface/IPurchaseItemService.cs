using InventoryManagement.CommandModel;
using InventoryManagement.QueryModel;

namespace InventoryManagement.Interface
{
    public interface IPurchaseItemService
    {
        Task<List<PurchaseItemQueryModel>> GetAllAsync();
        Task<PurchaseItemQueryModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(PurchaseItemCommandModel model);
        Task<bool> UpdateAsync(int id, PurchaseItemCommandModel model);
        Task<bool> DeleteAsync(int id);
    }
}
