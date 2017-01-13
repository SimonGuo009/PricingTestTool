using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingTool
{
    using static PricingTool.Browse;
    class Program
    {
        
        static void Main(string[] args)
        {
            Browse browse = new Browse();
            browse.NavigateTo(Product.AppService);
        }
    }
}
