using System;

namespace GroceryStorePOS
{
    public class InventoryItem : IComparable<InventoryItem>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ID { get; set; }
        public int QuantityInStock { get; set; }

        // Constructor to initialize the item
        public InventoryItem(string name, decimal price, int id, int quantityInStock)
        {
            Name = name;
            Price = price;
            ID = id;
            QuantityInStock = quantityInStock;
        }

        // Check if the item is low in stock
        public bool IsLowInStock(int threshold)
        {
            return QuantityInStock <= threshold;
        }

        public override string ToString()
        {
            return $"{Name}: {ID}\nIn stock: {QuantityInStock}\nPrice: {Price}\n";
        }

        // Compare two InventoryItem objects by their Name
        public int CompareTo(InventoryItem other)
        {
            if (other == null) return 1;  // If other is null, this object is greater
            return this.ID.CompareTo(other.ID);
        }
    }
}
