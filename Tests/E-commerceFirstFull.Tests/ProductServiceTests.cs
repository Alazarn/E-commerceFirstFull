using E_commerceFirstFull.Models;

using Xunit;

using System.Collections.Generic;
using System.Linq;
using E_commerceFirstFull.Services;

namespace E_commerceFirstFull.Tests
{
    public class ProductServiceTests
    {        
        [Fact]
        public void SortMethodReturnPriceDesc()
        {
            ProductTests productTests = new();
            var products = (IEnumerable<Product>)productTests.FormProduct();
            
            ProductService controller = new();

            var result = controller.SortProduct(ref products, SortState.PriceDesc).ToList();

            Assert.NotNull(result);
            Assert.Equal("Gothic II", result[0].Title);
        }
    }
}
