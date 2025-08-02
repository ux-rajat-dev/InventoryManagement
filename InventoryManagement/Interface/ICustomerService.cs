using InventoryManagement.CommandModel;
using InventoryManagement.QueryModel;

namespace InventoryManagement.Interface
{
    public interface ICustomerService
    {
        Task<List<CustomerQueryModel>> GetAllAsync();
        Task<CustomerQueryModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(CustomerCommandModel model);
        Task<bool> UpdateAsync(int id, CustomerCommandModel model);
        Task<bool> DeleteAsync(int id);
    }
}
