using NorthwindCatalog.Services.DTOs;
using Xunit;

namespace NorthwindCatalog.Tests
{
    public class ProductDTOTests
    {
        [Fact]
        public void InventoryValue_Should_Return_Correct_Value()
        {
            var product = new ProductDTO
            {
                ProductName = "Test",
                UnitPrice = 100.50m,
                UnitsInStock = 10
            };
            var inventoryValue = product.InventoryValue;
            Assert.Equal(1005.00m, inventoryValue);
        }
    }
}