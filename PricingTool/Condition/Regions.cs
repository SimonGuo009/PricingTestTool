using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingTool.Condition
{
    public static class Regions
    {
        public enum Region
        {
            us_central,
            us_east,
            us_east_2,
            us_north_central,
            us_south_central,
            us_west_central,
            us_west,
            us_west_2,

            europe_north,
            europe_west,

            asia_pacific_east,
            asia_pacific_southeast,

            japan_east,
            japan_west,

            brazil_south,

            australia_east,
            australia_southeast,

            central_india,
            south_india,
            west_india,

            canada_central,
            canada_east,

            germany_central,
            germany_northeast,

            united_kingdom_south,
            united_kingdom_west,

            usgov_iowa,
            usgov_virginia

        }

        public const string regionDropdownLocator = "region-selector";
    }
}
