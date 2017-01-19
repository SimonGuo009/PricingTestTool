using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingTool.Products
{
    public class AppService : Product
    {
        public AppService()
        {
            subUri = new Uri(Uri, "/pricing/details/app-service/");
        }
    }
}
