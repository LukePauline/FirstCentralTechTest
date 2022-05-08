using FirstCentralTechTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCentralTechTest.DataAccess
{
    public interface IProductRepository
    {
        public Product? Get(string sku);
    }
}
