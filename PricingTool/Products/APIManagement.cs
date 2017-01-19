using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingTool.Products
{
    class APIManagement : Product
    {
        public APIManagement()
        {
            subUri = new Uri(Uri, "/pricing/details/api-management/");
        }
    }
}
