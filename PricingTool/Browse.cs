using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace PricingTool
{
    public sealed class Browse : IDisposable
    {

        public IWebDriver Driver { get; set; }

        public Browse()
        {
            InitializeTest();
        }
        public void InitializeTest()
        {
            Driver = new FirefoxDriver();
            Driver.Manage().Window.Maximize();
        }
        
        public void NavigateTo(string url)
        {
            INavigation navigation = this.Driver.Navigate();
            navigation.GoToUrl(url);

            WaitForPageToLoad();
        }
        
        public void WaitForPageToLoad()
        {
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Parse("10"));
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
