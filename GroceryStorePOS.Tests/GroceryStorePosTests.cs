using System.Collections.Generic;
using Xunit;

namespace GroceryStorePOS.Tests
{
    public class GroceryStorePOSTests
    {
        [Fact]
        public void FindItemPrice_ItemExists_ReturnsCorrectPrice()
        {
            // Arrange
            var mockInventory = new Dictionary<string, decimal>
            {
                { "Apple", 0.99m },
                { "Banana", 0.59m },
                { "Milk", 3.49m }
            };
            var posSystem = new GroceryStorePOS(mockInventory);

            // Act
            var price = posSystem.FindItemPrice("Apple");

            // Assert
            Assert.Equal(0.99m, price);
        }

        [Fact]
        public void FindItemPrice_ItemDoesNotExist_ReturnsNull()
        {
            // Arrange
            var mockInventory = new Dictionary<string, decimal>
            {
                { "Apple", 0.99m },
                { "Banana", 0.59m }
            };
            var posSystem = new GroceryStorePOS(mockInventory);

            // Act
            var price = posSystem.FindItemPrice("Milk");

            // Assert
            Assert.Null(price);
        }

        [Fact]
        public void FindItemPrice_EmptyInventory_ReturnsNull()
        {
            // Arrange
            var mockInventory = new Dictionary<string, decimal>();
            var posSystem = new GroceryStorePOS(mockInventory);

            // Act
            var price = posSystem.FindItemPrice("Apple");

            // Assert
            Assert.Null(price);
        }

        [Fact]
        public void CalculateChange_ExactTender_ReturnsZero()
        {
            // Arrange
            var pos = new GroceryStorePOS(new Dictionary<string, decimal>());
            decimal orderTotal = 25.00m;
            decimal tenderGiven = 25.00m;

            // Act
            var change = pos.CalculateChange(orderTotal, tenderGiven);

            // Assert
            Assert.Equal(0.00m, change);
        }

        [Fact]
        public void CalculateChange_TenderGreaterThanOrder_ReturnsCorrectChange()
        {
            // Arrange
            var pos = new GroceryStorePOS(new Dictionary<string, decimal>());
            decimal orderTotal = 20.75m;
            decimal tenderGiven = 50.00m;

            // Act
            var change = pos.CalculateChange(orderTotal, tenderGiven);

            // Assert
            Assert.Equal(29.25m, change);
        }

        [Fact]
        public void CalculateChange_TenderLessThanOrder_ThrowsArgumentException()
        {
            // Arrange
            var pos = new GroceryStorePOS(new Dictionary<string, decimal>());
            decimal orderTotal = 30.00m;
            decimal tenderGiven = 20.00m;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => pos.CalculateChange(orderTotal, tenderGiven));
        }
    }
}

