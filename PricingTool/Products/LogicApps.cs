using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingTool.Products
{
    class LogicApps : Product
    {
        public LogicApps()
        {
            subUri = new Uri(Uri, "/pricing/details/logic-apps/");
        }
    }
}
