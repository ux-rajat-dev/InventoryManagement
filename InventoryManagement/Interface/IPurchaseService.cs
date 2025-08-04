using InventoryManagement.CommandModel;
using InventoryManagement.QueryModel;

namespace InventoryManagement.Interface
{
     
        public interface IPurchaseService
        {
            void Add(PurchaseCommandModel purchase);
            void Update(int purchaseId, PurchaseCommandModel purchase);
            void Remove(int purchaseId);
            PurchaseQueryModel GetPurchase(int purchaseId);
            List<PurchaseQueryModel> GetAllPurchases();
        }
    }

 
