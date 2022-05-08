using FirstCentralTechTest.DataAccess;
using FirstCentralTechTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCentralTechTestTests.Mocks
{
    internal class MockSpecialOfferRepository : ISpecialOfferRepository
    {
        Dictionary<string, SpecialOffer> _specialOffers = new Dictionary<string, SpecialOffer>()
        {
            { "A99", new SpecialOffer("A99", 3, 0.50) },
            { "B15", new SpecialOffer("B15", 2, 0.30) }
        };

        public SpecialOffer? Get(string sku)
        {
            if (_specialOffers.ContainsKey(sku))
                return _specialOffers[sku];

            return null;
        }
    }
}
