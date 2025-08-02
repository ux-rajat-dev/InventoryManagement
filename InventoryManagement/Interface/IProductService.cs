using InventoryManagement.CommandModel;
using InventoryManagement.QueryModel;

namespace InventoryManagement.Interface
{
    public interface IProductService
    {
        Task<List<ProductQueryModel>> GetAllAsync();
        Task<ProductQueryModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(ProductCommandModel model);
        Task<bool> UpdateAsync(int id, ProductCommandModel model);
        Task<bool> DeleteAsync(int id);
    }

}
