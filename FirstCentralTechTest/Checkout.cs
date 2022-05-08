using FirstCentralTechTest.DataAccess;
using FirstCentralTechTest.Models;

namespace FirstCentralTechTest
{
    public class Checkout
    {
        private readonly IProductRepository _productRepository;
        private readonly ISpecialOfferRepository _specialOfferRepository;

        public Checkout(IProductRepository productRepository, ISpecialOfferRepository specialOfferRepository)
        {
            _productRepository = productRepository;
            _specialOfferRepository = specialOfferRepository;
        }

        public Dictionary<string, int> Cart { get; set; } = new Dictionary<string, int>();

        public void ScanItem(string sku)
        {
            var product = _productRepository.Get(sku);

            // should probably indicate here that the product doesn't exist rather than just returning
            if (product == null)
                return;

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
                var specialOffer = _specialOfferRepository.Get(item.Key);
                if (specialOffer is null)
                {
                    subtotal += product.UnitPrice * item.Value;
                }
                else
                {
                    var offers = item.Value / specialOffer.Quantity;
                    var extra = item.Value % specialOffer.Quantity;
                    subtotal += specialOffer.Price * offers;
                    subtotal += product.UnitPrice * extra;
                }
            }

            return subtotal;
        }
    }
}