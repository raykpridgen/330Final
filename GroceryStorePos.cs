using System.Collections.Generic;
using System.Linq;
using System;
namespace GroceryStorePOS
{
    public class GroceryStorePOS
    {
        private readonly Dictionary<string, decimal> _inventory;
        private readonly List<InventoryItem> _items;

        public GroceryStorePOS(Dictionary<string, decimal> inventory, List<InventoryItem> items)
        {
            _inventory = inventory;
            _items = items;
        }

        /*
        As a cashier, I want to find an item by name so that I can find the price for a customer without leaving my station.
        */
        public decimal? FindItemPrice(string itemName)
        {
            if (_inventory.TryGetValue(itemName, out decimal price))
            {
                return price;
            }
            return null;
        }

        /*
        As a cashier, I want to determine the change needed based on a customer's order and the tender they used,
        so that I am not spending a lot of time counting change. 
        */
        public decimal CalculateChange(decimal orderTotal, decimal tenderGiven)
        {
            if (tenderGiven < orderTotal)
                throw new ArgumentException("Tender given must be greater than or equal to the order total.");

            return tenderGiven - orderTotal;
        }

        /*
        As a shift manager, I want to be able to search the inventory for all available items, 
        so that I can manage our inventory and prevent shortages.
        */
        public void DisplayAllItems()
        {
            foreach (InventoryItem item in _items)
            {
                Console.WriteLine(item.ToString());
            }
        }

        /*
        As a shift manager, I want to filter inventory by low-in-stock items, 
        so that I can keep track of items the team needs to restock.
        */
        public List<InventoryItem> FilterLowStockItems(int threshold)
        {
            return _items.Where(i => i.IsLowInStock(threshold)).ToList();
        }


    }
}


