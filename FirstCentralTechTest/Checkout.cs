using FirstCentralTechTest.DataAccess;
using FirstCentralTechTest.Models;

namespace FirstCentralTechTest
{
    public class Checkout
    {
        private readonly IProductRepository _productRepository;

        public Checkout(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Dictionary<string, int> Cart { get; set; } = new Dictionary<string, int>();

        public void ScanItem(string sku)
        {
            if (Cart.ContainsKey(sku))
                Cart[sku]++;
            else
                Cart.Add(sku, 1);
        }
    }
}