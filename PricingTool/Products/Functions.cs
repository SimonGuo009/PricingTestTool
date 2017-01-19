using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingTool.Products
{
    class Functions : Product
    {
        public Functions()
        {
            subUri = new Uri(Uri, "/pricing/details/functions/");
        }
    }
}
