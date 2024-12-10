using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillDeCojones
{
    internal class InformeDeLaCuenta
    {
        public string account_name { get; set; }
        public DateTime creation_date { get; set; }
        public int num_products { get; set; }
        public int num_categories { get; set; }
        public int num_attributes { get; set; }
        public int num_relationships { get; set; }
    }
}
