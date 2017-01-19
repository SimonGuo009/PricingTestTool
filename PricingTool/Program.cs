using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingTool
{
    using Products;
    using static ExcelOutput;
    using static Products.Product;
    using static Condition.Regions;
    using static Condition.Currencies;

    class Program
    {
        static void Main(string[] args)
        {
            //ProductName product = ProductName.AppService;
            //Region region = Region.asia_pacific_east;
            //Currency currency_1 = Currency.USD;
            //Currency currency_2 = Currency.ARS;
            //double exchangeRate = 15.7;

            //string condition = product.ToString() + " ■ " + region.ToString() + " ■ " + currency_2.ToString();

            //List<double> calculatedDatas = GetExactPricings(product, region, currency_1, exchangeRate);
            //List<double> exactPricingDatas = GetExactPricings(product, region, currency_2);

            //CreateExcelFile();
            //WriteToExcel(condition, calculatedDatas, exactPricingDatas);

            CreateExcelFile();
            GetAllPricings(Currency.ARS, 15.7);
            
        }

        static void WriteDatasPerPage(ProductName product, Region region, Currency currency, double exchangeRate)
        {
            string condition = product.ToString() + " ■ " + region.ToString() + " ■ " + currency.ToString();

            List<double> calculatedDatas = GetExactPricings(product, region, Currency.USD, exchangeRate);
            List<double> exactPricingDatas = GetExactPricings(product, region, currency);

            WriteToExcel(condition, calculatedDatas, exactPricingDatas);
        }

        static List<double> GetExactPricings(ProductName product, Region region, Currency currency, double rate = 1)
        {
            Product prod = CreateProduct(product);
            Browse browse = new Browse();
            browse.NavigateTo(prod.subUri.ToString());

            SetRegionViaValue(browse, region);
            SetCurrencyViaValue(browse, currency);

            return GetPricingDataFromPage(browse, rate);
        }

        static void GetAllPricings(Currency currency, double exchangeRate)
        {
            Browse browse = new Browse();

            //Enum 遍历操作，第一层遍历
            foreach (ProductName prodInEnum in Enum.GetValues(typeof(ProductName)))
            {
                Product productObject = CreateProduct(prodInEnum);
                productObject.OpenProductPricingPage(browse);

                //遍历available region
                foreach (var availableRegion in Helper.GetAvailableRegions(browse))
                {
                    //GetAvailableRegions方法得到的region的value属性就是我们下拉框选择的依据
                    string regionName = availableRegion.GetAttribute("value");
                    Helper.SelectOption(browse, regionDropdownLocator, regionName);

                    Helper.SelectOption(browse, currencyDropdownLocator, currency.ToString());

                    //Region name string -> Region enum
                    Region region = (Region)Enum.Parse(typeof(Region), regionName.Replace("-", "_"),false);

                    WriteDatasPerPage(prodInEnum, region, currency, exchangeRate);

                    ////遍历currency
                    //foreach (string currencyName in Enum.GetNames(typeof(Currency)))
                    //{
                    //    Helper.SelectOption(browse, currencyDropdownLocator, currencyName);

                    //    WriteDatasPerPage(productObject,regionName,currencyName,)

                    //    //输出1 - 计算值

                    //    //输出2 - 实际值
                    //}
                }
            }
        }

        //Easy output
        private static string PrintListOnConsole(List<double> arrayToPrint)
        {
            string str = "";

            foreach (var item in arrayToPrint)
            {
                str += item.ToString();
                str += "\t";
            }

            return str;
        }

        //Product factory
        static Product CreateProduct(ProductName productName)
        {
            Product product = null;
            switch (productName)
            {
                //case ProductName.LinuxVirtualMachines: product = new LinuxVirtualMachines(); break;
                //case ProductName.WindowsVirtualMachines: product = new WindowsVirtualMachines(); break;
                //case ProductName.VirtualMachineScaleSets: product = new VirtualMachineScaleSets(); break;
                case ProductName.AppService: product = new AppService(); break;
                //case ProductName.AzureContainerService: product = new AzureContainerService(); break;
                //case ProductName.AzureContainerRegistry: product = new AzureContainerRegistry(); break;
                case ProductName.Functions: product = new Functions(); break;
                //case ProductName.Batch: product = new Batch(); break;
                //case ProductName.ServiceFabric: product = new ServiceFabric(); break;
                //case ProductName.CloudServices: product = new CloudServices(); break;
                //case ProductName.VirtualNetwork: product = new VirtualNetwork(); break;
                //case ProductName.LoadBalancer: product = new LoadBalancer(); break;
                //case ProductName.ApplicationGateway: product = new ApplicationGateway(); break;
                //case ProductName.VPNGateway: product = new VPNGateway(); break;
                //case ProductName.AzureDNS: product = new AzureDNS(); break;
                //case ProductName.ContentDeliveryNetwork: product = new ContentDeliveryNetwork(); break;
                //case ProductName.TrafficManager: product = new TrafficManager(); break;
                //case ProductName.ExpressRoute: product = new ExpressRoute(); break;
                //case ProductName.Bandwidth: product = new Bandwidth(); break;
                case ProductName.Storage: product = new Storage(); break;
                //case ProductName.DataLakeStore: product = new DataLakeStore(); break;
                //case ProductName.StorSimple: product = new StorSimple(); break;
                //case ProductName.Backup: product = new Backup(); break;
                //case ProductName.SiteRecovery: product = new SiteRecovery(); break;
                case ProductName.LogicApps: product = new LogicApps(); break;
                //case ProductName.MediaServices: product = new MediaServices(); break;
                //case ProductName.AzureSearch: product = new AzureSearch(); break;
                //case ProductName.MobileEngagement: product = new MobileEngagement(); break;
                case ProductName.APIManagement: product = new APIManagement(); break;
                //case ProductName.NotificationHubs: product = new NotificationHubs(); break;
                //case ProductName.SQLDatabase: product = new SQLDatabase(); break;
                //case ProductName.SQLDataWarehouse: product = new SQLDataWarehouse(); break;
                //case ProductName.SQLServerStretchDatabase: product = new SQLServerStretchDatabase(); break;
                //case ProductName.DocumentDB: product = new DocumentDB(); break;
                //case ProductName.RedisCache: product = new RedisCache(); break;
                //case ProductName.DataFactory: product = new DataFactory(); break;
                //case ProductName.HDInsight: product = new HDInsight(); break;
                //case ProductName.MachineLearning: product = new MachineLearning(); break;
                //case ProductName.StreamAnalytics: product = new StreamAnalytics(); break;
                //case ProductName.CognitiveServices: product = new CognitiveServices(); break;
                //case ProductName.AzureBotService: product = new AzureBotService(); break;
                //case ProductName.DataLakeAnalytics: product = new DataLakeAnalytics(); break;
                //case ProductName.PowerBIEmbedded: product = new PowerBIEmbedded(); break;
                //case ProductName.DataCatalog: product = new DataCatalog(); break;
                //case ProductName.LogAnalytics: product = new LogAnalytics(); break;
                //case ProductName.AzureAnalysisServices: product = new AzureAnalysisServices(); break;
                //case ProductName.Dynamics365forCustomerInsights: product = new Dynamics365forCustomerInsights(); break;
                //case ProductName.AzureIoTHub: product = new AzureIoTHub(); break;
                //case ProductName.EventHubs: product = new EventHubs(); break;
                //case ProductName.BizTalkServices: product = new BizTalkServices(); break;
                //case ProductName.ServiceBus: product = new ServiceBus(); break;
                //case ProductName.SecurityCenter: product = new SecurityCenter(); break;
                //case ProductName.KeyVault: product = new KeyVault(); break;
                //case ProductName.AzureActiveDirectory: product = new AzureActiveDirectory(); break;
                //case ProductName.AzureActiveDirectoryB2C: product = new AzureActiveDirectoryB2C(); break;
                //case ProductName.AzureActiveDirectoryDomainServices: product = new AzureActiveDirectoryDomainServices(); break;
                //case ProductName.MultiFactorAuthentication: product = new MultiFactorAuthentication(); break;
                //case ProductName.VisualStudioTeamServices: product = new VisualStudioTeamServices(); break;
                //case ProductName.AzureDevTestLabs: product = new AzureDevTestLabs(); break;
                //case ProductName.ApplicationInsights: product = new ApplicationInsights(); break;
                //case ProductName.HockeyApp: product = new HockeyApp(); break;
                //case ProductName.Automation: product = new Automation(); break;
                //case ProductName.Scheduler: product = new Scheduler(); break;
                //case ProductName.AzureMonitor: product = new AzureMonitor(); break;
                //case ProductName.SecurityAndCompliance: product = new SecurityAndCompliance(); break;
                //case ProductName.ProtectionAndRecovery: product = new ProtectionAndRecovery(); break;
                //case ProductName.AutomationAndControl: product = new AutomationAndControl(); break;
                //case ProductName.InsightAndAnalytics: product = new InsightAndAnalytics(); break;
                //case ProductName.Advisor: product = new Advisor(); break;

                default: product = new Product(); break;
            }
            return product;
        }

    }
}
