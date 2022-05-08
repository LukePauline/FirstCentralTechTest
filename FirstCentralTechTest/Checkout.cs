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

        public double GetTotal()
        {
            // could do this with linq but the special offer logic could get a bit messy in a lambda
            double subtotal = 0;

            foreach (var item in Cart)
            {
                var product = _productRepository.Get(item.Key);
                subtotal += product.UnitPrice * item.Value;
            }

            return subtotal;
        }
    }
}