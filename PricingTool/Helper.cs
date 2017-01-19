using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace PricingTool
{

    static class Helper
    {
        public static void Click(Browse browse, string location)
        {
            IWebDriver driver = browse.Driver;
            driver.FindElement(By.XPath(location)).Click();
            browse.WaitForPageToLoad();
        }

        public static void SelectOption(Browse browse, string location, int index)
        {
            IWebDriver driver = browse.Driver;

            //A class of Selenium to treat dropdown
            SelectElement sel = new SelectElement(driver.FindElement(By.Id(location)));
            sel.SelectByIndex(index);

            browse.WaitForPageToLoad();
        }

        public static void SelectOption(Browse browse, string location, string value)
        {
            IWebDriver driver = browse.Driver;

            //If there are 'value' parameters under option tag, find option via it will increase accuracy
            SelectElement sel = new SelectElement(driver.FindElement(By.Id(location)));
            sel.SelectByValue(value);

            browse.WaitForPageToLoad();
        }

        #region Find Element
        public static IWebElement FindElementByID(Browse browse, string id)
        {
            IWebDriver driver = browse.Driver;
            return driver.FindElement(By.Id(id));
        }

        public static IWebElement FindElementByClassName(Browse browse, string className)
        {
            IWebDriver driver = browse.Driver;
            return driver.FindElement(By.ClassName(className));
        }

        public static IWebElement FindElementByTagName(Browse browse, string tagName)
        {
            IWebDriver driver = browse.Driver;
            return driver.FindElement(By.TagName(tagName));
        }

        public static IWebElement FindElementByLinkText(Browse browse, string linkText)
        {
            IWebDriver driver = browse.Driver;
            return driver.FindElement(By.LinkText(linkText));
        }

        public static IWebElement FindElementByCss(Browse browse, string css)
        {
            IWebDriver driver = browse.Driver;
            return driver.FindElement(By.CssSelector(css));
        }

        public static IWebElement FindElementByName(Browse browse, string name)
        {
            IWebDriver driver = browse.Driver;
            return driver.FindElement(By.Name(name));
        }

        public static IWebElement FindElementByXpath(Browse browse, string xpath)
        {
            IWebDriver driver = browse.Driver;
            return driver.FindElement(By.XPath(xpath));
        }
        #endregion

        #region Find Elements

        public static IReadOnlyCollection<IWebElement> FindElementsByClassName(Browse browse, string className)
        {
            IWebDriver driver = browse.Driver;
            return driver.FindElements(By.ClassName(className));
        }

        public static IReadOnlyCollection<IWebElement> FindElementsByTagName(Browse browse, string tagName)
        {
            IWebDriver driver = browse.Driver;
            return driver.FindElements(By.TagName(tagName));
        }

        public static IReadOnlyCollection<IWebElement> FindElementsByLinkText(Browse browse, string linkText)
        {
            IWebDriver driver = browse.Driver;
            return driver.FindElements(By.LinkText(linkText));
        }

        public static IReadOnlyCollection<IWebElement> FindElementsByCss(Browse browse, string css)
        {
            IWebDriver driver = browse.Driver;
            return driver.FindElements(By.CssSelector(css));
        }

        public static IReadOnlyCollection<IWebElement> FindElementsByName(Browse browse, string name)
        {
            IWebDriver driver = browse.Driver;
            return driver.FindElements(By.Name(name));
        }

        public static IReadOnlyCollection<IWebElement> FindElementsByXpath(Browse browse, string xpath)
        {
            IWebDriver driver = browse.Driver;
            return driver.FindElements(By.XPath(xpath));
        }
        #endregion

        public static IReadOnlyCollection<IWebElement> GetAvailableRegions(Browse browse)
        {
            IWebDriver driver = browse.Driver;

            return driver.FindElements(By.XPath("//option[@class='']"));
            
        }

        /// <summary>
        /// This function is to unformat a price like $ 17,000 -> 17000
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        public static double PriceUnformat(string sample)
        {
            string[] symbolToDelete = { ",", "$", "chf", "kr", "Rp", "¥", "₩", "руб", "SR", "R", "NT$", "TL", "£", "MXN$", "RM$", "₹", "HK$", "R$" };

            for (int i = 0; i < symbolToDelete.Length; i++)
            {
                if (sample == "") break;
                sample = sample.Replace(symbolToDelete[i], "");
            }
            sample.Trim();

            try
            {
                return Convert.ToDouble(sample);
            }
            catch
            {
                return 0;
            }
        }
    }
}
