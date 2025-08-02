using InventoryManagement.CommandModel;
using InventoryManagement.QueryModel;

namespace InventoryManagement.Interface
{
    public interface ISupplierService
    {
        Task<List<SupplierQueryModel>> GetAllAsync();
        Task<SupplierQueryModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(SupplierCommandModel model);
        Task<bool> UpdateAsync(int id, SupplierCommandModel model);
        Task<bool> DeleteAsync(int id);
    }
}
