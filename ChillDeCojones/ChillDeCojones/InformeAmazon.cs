using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillDeCojones
{
    internal class InformeAmazon
    {
        public string accountName { get; set; }
        public string SKU { get; set; }
        public string GTIN { get; set; }
        public int productName { get; set; }
        public int price { get; set; }
        public int offerPrime { get; set; }
    }
}
