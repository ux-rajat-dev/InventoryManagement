using InventoryManagement.CommandModel;
using InventoryManagement.QueryModel;

namespace InventoryManagement.Interface
{
    public interface ISaleService
    {
        
            void Add(SaleCommandModel sale);
            void Update(int saleId, SaleCommandModel sale);
            void Remove(int saleId);
            SaleQueryModel GetSale(int saleId);
            List<SaleQueryModel> GetAllSales();
        }
}


