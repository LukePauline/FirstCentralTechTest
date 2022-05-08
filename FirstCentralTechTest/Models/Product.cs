using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCentralTechTest.Models
{
    public class Product
    {
        public Product(string sku, double unitPrice)
        {
            Sku = sku;
            UnitPrice = unitPrice;
        }

        public string Sku { get; set; }

        public double UnitPrice { get;set; }
    }
}
