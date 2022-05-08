using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstCentralTechTest.DataAccess;
using FirstCentralTechTest.Models;

namespace FirstCentralTechTestTests.Mocks
{
    // In a real situation, I probably would've looked into mocking these repositories with a mocking framework like Moq but this works just fine
    internal class MockProductRepository : IProductRepository
    {
        Dictionary<string, Product> _products = new Dictionary<string, Product>()
        {
            { "A99", new Product("A99", 0.50) },
            { "B15", new Product("B15", 0.30) },
            { "C40", new Product("C40", 0.60) }
        };

        public Product? Get(string sku)
        {
            if (_products.ContainsKey(sku))
                return _products[sku];

            return null;
        }
    }
}
