using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingTool.Products
{
    using static Condition.Regions;
    using static Condition.Currencies;
    using System.Collections;
    public class Product
    {
        private Uri uri = new Uri("https://azure.microsoft.com/en-us");

        public Uri subUri { get; set; }

        public Uri Uri
        {
            get
            {
                return uri;
            }

            set
            {
                uri = value;
            }
        }

        public Product()
        {
        }

        public void OpenProductPricingPage()
        {
            Browse browse = new Browse();
            browse.NavigateTo(Uri.AbsolutePath);
        }

        public static void SetRegionViaIndex(Browse browse, Region region)
        {
            Helper.SelectOption(browse, regionDropdownLocator, Convert.ToInt32(region));
        }

        public static void SetRegionViaValue(Browse browse, Region region)
        {
            string value = region.ToString().Replace('_', '-');
            Helper.SelectOption(browse, regionDropdownLocator, value);
        }
        
        public static void SetCurrencyViaIndex(Browse browse, Currency currency)
        {
            Helper.SelectOption(browse, currencyDropdownLocator, Convert.ToInt32(currency));
        }
        
        public static void SetCurrencyViaValue(Browse browse, Currency currency)
        {
            Helper.SelectOption(browse, currencyDropdownLocator, currency.ToString());
        }

        /// <summary>
        /// This function is to get all currency related price values
        /// </summary>
        /// <param name="browse">To get driver object</param>
        /// <param name="rate">Fill this param to get value then calculate price for target currency</param>
        /// <returns></returns>
        public static List<double> GetPricingDataFromPage(Browse browse, double rate = 1)
        {
            List<double> list = new List<double>();
            //IWebElement element = driver.FindElement(By.ClassName("price-data"));
            //return element.Text;
            foreach (var item in Helper.FindElementsByClassName(browse, "price-data"))
            {

                double price = Helper.PriceUnformat(item.Text) * rate;
                list.Add(price);
            }
            return list;
        }

        public enum ProductName
        {
            LinuxVirtualMachines,
            WindowsVirtualMachines,
            VirtualMachineScaleSets,
            AppService,
            AzureContainerService,
            AzureContainerRegistry,
            Functions,
            Batch,
            ServiceFabric,
            CloudServices,
            VirtualNetwork,
            LoadBalancer,
            ApplicationGateway,
            VPNGateway,
            AzureDNS,
            ContentDeliveryNetwork,
            TrafficManager,
            ExpressRoute,
            Bandwidth,
            Storage,
            DataLakeStore,
            StorSimple,
            Backup,
            SiteRecovery,
            LogicApps,
            MediaServices,
            AzureSearch,
            MobileEngagement,
            APIManagement,
            NotificationHubs,
            SQLDatabase,
            SQLDataWarehouse,
            SQLServerStretchDatabase,
            DocumentDB,
            RedisCache,
            DataFactory,
            HDInsight,
            MachineLearning,
            StreamAnalytics,
            CognitiveServices,
            AzureBotService,
            DataLakeAnalytics,
            PowerBIEmbedded,
            DataCatalog,
            LogAnalytics,
            AzureAnalysisServices,
            Dynamics365forCustomerInsights,
            AzureIoTHub,
            EventHubs,
            BizTalkServices,
            ServiceBus,
            SecurityCenter,
            KeyVault,
            AzureActiveDirectory,
            AzureActiveDirectoryB2C,
            AzureActiveDirectoryDomainServices,
            MultiFactorAuthentication, //_
            VisualStudioTeamServices,
            AzureDevTestLabs,
            ApplicationInsights,
            HockeyApp,
            Automation,
            Scheduler,
            AzureMonitor,
            SecurityAndCompliance, //&
            ProtectionAndRecovery, //&
            AutomationAndControl, //&
            InsightAndAnalytics, //&
            Advisor
        }
    }
}
