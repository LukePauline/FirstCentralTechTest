using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCentralTechTest.Models
{
    // I made this a record considering using it as the key for my dictionary (implements equals/GetHash and duck typing) but quickly decided against that,
    // but as a record it works just as well for this task. In a real situation, this would be linked to a db
    // somewhere and I'd probably want to mark it up with attributes for an ORM like entity framework so it'd need
    // converting back into a class proper
    public record Product(string Sku, double UnitPrice);
}
