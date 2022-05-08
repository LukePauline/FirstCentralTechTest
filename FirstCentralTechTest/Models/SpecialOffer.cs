using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCentralTechTest.Models
{
    public class SpecialOffer
    {
        public SpecialOffer(string sku, int quantity, double price)
        {
            Sku = sku;
            Quantity = quantity;
            Price = price;
        }

        public string Sku { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
