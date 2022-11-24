using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

namespace Test.Services
{
    public class ItemService : IItemService
    {
        private readonly DataContext _context;
        public ItemService(DataContext context)
        {
            _context = context;
        }

        //post
        public void AddItem(Inventory item)
        {
            var dbItem = _context.Items;
            //item.itemId = dbItem.Count + 1;
            dbItem.Add(item);
        }
        //get
        public List<Inventory> GetAll()
        {
            var dbItem = _context.Items.ToList();
            return dbItem;
        }

        public Inventory GetByUser(int userId)
        {
            var dbUser = _context.Users.ToList();
            var dbItem = _context.Items.ToList();
            Inventory emptyItem = new Inventory();
            foreach(Inventory item in dbItem)
            {
                if(item.userId == userId)
                {
                    return item;
                }
            }
            return emptyItem;
        }

        //Get
        public Inventory GetItem(int id)
        {
            var dbItem = _context.Items.ToList();
            Inventory emptyItem = new Inventory();
            foreach (Inventory item in dbItem)
            {
                if (item.itemId == id)
                {
                    return item;
                }
            }
            return emptyItem;
        }
        //put
        public void UpdateItem(Inventory itemToUpdate, int userId)
        {
            var dbItem = _context.Items;

            foreach (Inventory item in dbItem)
            {
                if (item.itemId == userId)
                {

                    item.itemId = itemToUpdate.itemId;
                    item.Name = itemToUpdate.Name;
                    item.Description = itemToUpdate.Description;
                    item.Quantity = itemToUpdate.Quantity;
                    _context.SaveChanges();
                }
            }
        }
        public void TradeItem(int idItem, int userTraded, int userToTrade, int quantityTrade)
        {
            var dbItem = _context.Items;
            foreach (Inventory item in dbItem)
            {
                if(item.itemId == idItem)
                {
                    if(item.userId == userTraded)
                    {
                        if(item.Quantity-quantityTrade > 0)
                        {
                            //crear un nuevo item con el resultado de la resta
                            item.userId = userToTrade;
                            dbItem.Add(item);
                        }
                        else
                        {
                            if(item.Quantity-quantityTrade < 0)
                            {
                                break;
                            }
                            else
                            {
                                //borrar
                                dbItem.Remove(item);
                                _context.SaveChanges();
                            }
                        }   
                    }
                }
            }
        }


        //delete
        public void DeleteItem(int id)
        {
            var dbItem = _context.Items;
            foreach (Inventory item in dbItem)
            {
                if (item.itemId == id)
                {
                    dbItem.Remove(item);
                    _context.SaveChanges();
                }
            }

        }
    }
}
