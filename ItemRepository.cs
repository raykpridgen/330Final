using System;
using System.Collections.Generic;
namespace GroceryStorePOS
{
    public interface IItemRepository
    {
        List<InventoryItem> Items {get;set;}
    }
    public class ItemRepository : IItemRepository
    {
        public List<InventoryItem> Items {get;set;}

        public ItemRepository() {
            Items = new List<InventoryItem>();
           
            InventoryItem a1 = new InventoryItem("Chips", (decimal)2.99, 33345, 499);
            InventoryItem a2 = new InventoryItem("Water", (decimal)1.99, 12345, 34);
            InventoryItem a3 = new InventoryItem("Brownies", (decimal)4.99, 45678, 22);
            
            
            Items.Add(a1);
            Items.Add(a2);
            Items.Add(a3);
            

        }
    }
}