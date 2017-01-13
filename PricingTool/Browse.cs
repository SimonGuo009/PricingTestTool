using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Selenium;
using System.Configuration;


namespace PricingTool
{
    public class Browse
    {               
        IWebDriver driver;
             
        public void InitializeTest()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        //Products Names, used for getting url suffix from appsettings
        public enum Product
        {
            AppService,
            Functions,
            LogicApps,
            Storage,
            APIManagement
        }

        public void NavigateTo(Product product)
        {
            InitializeTest();
            INavigation navigation = this.driver.Navigate();

            navigation.GoToUrl(Of(product));
        }

        //For combining url strings
        private static string Of(Product product)
        {
            return "https://azure.microsoft.com/en-us" + ConfigurationManager.AppSettings[product.ToString()];
        }

        //implementing
        public void WaitForPageToLoad()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Parse("10"));
        }

        
    }
}
