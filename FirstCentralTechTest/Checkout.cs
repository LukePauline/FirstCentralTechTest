using FirstCentralTechTest.DataAccess;
using FirstCentralTechTest.Models;

namespace FirstCentralTechTest
{
    // Ideally, this class would implement an interface so any future objects that depended on this could be tested with a mock
    // I've only implemented logic required for the test but I'd assume that it would also need methods for removing items, flagging age restrictions etc.
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
            // could return a boolean or if it were more complex, a enum describing the status of the scan
            if (product == null)
                return;

            if (Cart.ContainsKey(sku))
                Cart[sku]++;
            else
                Cart.Add(sku, 1);
        }

        public double GetTotal()
        {
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
                    // Working under the assumption here that for an with quantity of 3, offer price applies to each group of 3 and any remainder is charged regularly
                    // I would want to check that assumption is correct if carrying this forward
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