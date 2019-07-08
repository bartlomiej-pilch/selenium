using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using swd.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swd.PageObjects
{
    public abstract class BasePage : IDisposable
    {
        protected BrowserType BrowserType { get; }
        protected IWebDriver Driver { get; set; }
        public string Title { get { return Driver.Title; } }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public BasePage(BrowserType browserType)
        {
            BrowserType = browserType;
            InitializeDriver();
        }

        private void InitializeDriver()
        {
            switch (BrowserType)
            {
                case BrowserType.Chrome:
                    Driver = new ChromeDriver();
                    break;
                case BrowserType.FF:
                    Driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
 

        [FindsBy(How=How.XPath,Using = "//a[text()='Playoffs']")]
        protected By playoffsLocator { get; set; }



        public void waitForTitleTextInPageDOM(int secondsToWait, String expectedText)
        {
            TimeSpan span = new TimeSpan(0, 0, secondsToWait);
            WebDriverWait wait = new WebDriverWait(Driver, span);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains(expectedText));
        }

        public void waitForElementToBeVisible(int secondsToWait,By by)
        {
            TimeSpan span = new TimeSpan(0, 0, secondsToWait);
            WebDriverWait wait = new WebDriverWait(Driver, span);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        public void Click(By by)
        {
            try
            {
                Driver.FindElement(by).Click();
            }
            catch (ElementNotInteractableException)
            {
                Click(Driver.FindElement(playoffsLocator));
            }
        }

        private void Click(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].click();", element);
            Console.WriteLine("jsClick applied!");
        }

        public void Assertion(String a, String b)
        {
            Assert.That(a == b, "assertion fail");
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                if (Driver != null)
                    Driver.Quit();

                disposedValue = true;
            }
        }

         ~BasePage()
        {
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
           Dispose(true);
        }
        #endregion
    }

}
