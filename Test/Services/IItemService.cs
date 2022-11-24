using Test.Models;

namespace Test.Services
{
    public interface IItemService
    {
    
        void AddItem(Inventory item);
       
        void UpdateItem(Inventory item, int itemId);
        void TradeItem(int idItem, int userId, int userId2, int quantityTrade);
      
        Inventory GetItem(int id);
      
        List<Inventory> GetAll();
     
        List<Inventory> GetByUser(int userId);
      
        void DeleteItem(int id);

    }
}
