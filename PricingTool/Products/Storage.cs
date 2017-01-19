using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingTool.Products
{
    class Storage : Product
    {
        public Storage()
        {
            subUri = new Uri(Uri, "/pricing/details/storage/blobs/");
        }
    }
}
