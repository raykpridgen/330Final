using System;
using System.Collections.Generic;
namespace GroceryStorePOS
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemRepository repo = new ItemRepository();
            GroceryStorePOS storePOS = new GroceryStorePOS(new Dictionary<string, decimal>(), repo.Items);

            Console.WriteLine("Items with a low stock: \n");
            var lowStockItems = storePOS.FilterLowStockItems(100);
            foreach (var item in lowStockItems)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("All items: \n");
            storePOS.DisplayAllItems();


            

        }//end main
    }
}
