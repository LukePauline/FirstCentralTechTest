using FirstCentralTechTest.Models;

namespace FirstCentralTechTest.DataAccess
{
    public interface ISpecialOfferRepository
    {
        public SpecialOffer? Get(string sku);
    }
}
