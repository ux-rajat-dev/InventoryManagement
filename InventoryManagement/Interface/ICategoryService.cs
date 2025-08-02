using InventoryManagement.CommandModel;
using InventoryManagement.QueryModel;

namespace InventoryManagement.Interface
{
    public interface ICategoryService
    {
        Task<List<CategoryQueryModel>> GetAllAsync();
        Task<CategoryQueryModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(CategoryCommandModel model);
        Task<bool> UpdateAsync(int id, CategoryCommandModel model);
        Task<bool> DeleteAsync(int id);
    }
}
