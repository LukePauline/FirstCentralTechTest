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

        public double SubTotal => Cart.Sum(x => x.Value * x.Key.UnitPrice);
        public Dictionary<Product, int> Cart { get; set; } = new Dictionary<Product, int>();

        public void ScanItem(string sku)
        {
            var product = _productRepository.Get(sku);
            if (Cart.ContainsKey(product))
                Cart[product]++;
            else
                Cart.Add(product, 1);
        }
    }
}