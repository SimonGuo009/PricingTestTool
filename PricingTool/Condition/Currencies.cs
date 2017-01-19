using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingTool.Condition
{
    public static class Currencies
    {
        public enum Currency
        {
            USD, //US Dollar($)
            EUR, //Euro(€)
            CHF, //Swiss Franc. (chf)
            ARS, //Argentine Peso($)
            AUD, //Australian Dollar($)
            DKK, //Danish Krone(kr)
            CAD, //Canadian Dollar($)
            IDR, //Indonesian Rupiah(Rp)
            JPY, //Japanese Yen(¥)
            KRW, //Korean Won(₩)
            NZD, //New Zealand Dollar($) 
            NOK, //Norwegian Krone(kr) 
            RUB, //Russian Ruble(руб) 
            SAR, //Saudi Riyal(SR) 
            ZAR, //South African Rand(R) 
            SEK, //Swedish Krona(kr) 
            TWD, //Taiwanese Dollar(NT$)   
            TRY, //Turkish Lira(TL) 
            GBP, //British Pound(£) 
            MXN, //Mexican Peso(MXN$)   
            MYR, //Malaysian Ringgit(RM$) 
            INR, //Indian Rupee(₹) 
            HKD, //Hong Kong Dollar(HK$)
            BRL, //Brazilian Real(R$)
        }

        public const string currencyDropdownLocator = "currency-selector";
        
    }
}
