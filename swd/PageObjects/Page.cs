using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swd
{
    public class Page
    {
        public IWebDriver driver;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static NhlMainPage NavigateToNhlMainPage(IWebDriver driver)
        {
            String url = "http://nhl.com";
            Console.WriteLine("Opening page: " + url);
            driver.Navigate().GoToUrl(url);
            Console.WriteLine("Page: " + url + " opened!");
            return new NhlMainPage(driver);
        }

        public static void waitForTitleTextInPageDOM(IWebDriver driver,int secondsToWait, String expectedText)
        {
            TimeSpan span = new TimeSpan(0, 0, secondsToWait);
            WebDriverWait wait = new WebDriverWait(driver, span);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains(expectedText));
        }

        public static void Click(IWebDriver driver, By by)
        {
            driver.FindElement(by).Click();
        }

        public static void Assertion(String a, String b)
        {
            Assert.That(a == b, "assertion fail");
        }
    }

}
