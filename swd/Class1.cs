using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace swd
{
    class FirstTest
    {
        [Test]
        public void osomTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.google.com");


            //IWebElement searchField = driver.FindElement(By.Name("q"));
            TimeSpan span = new TimeSpan(0, 0, 0, 0, 2);

            WebDriverWait wait = new WebDriverWait(driver, span);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//input[@type='text']")));
            IWebElement searchField = driver.FindElement(By.XPath("//input[@type='text']"));
            searchField.SendKeys("chuju"+Keys.Enter);

            IWebElement results = driver.FindElement(By.Id("resultStats"));

            String pageSource = driver.PageSource.ToString();

            Assert.AreEqual(results.Displayed, true);
            Assert.True(results.Displayed);
            Assert.True(pageSource.Contains("chuju - Szukaj w Google"));


            
         /*   try
            {
                Thread.Sleep(2000);
            }
            catch (ThreadInterruptedException e)
            {
                System.Console.Out.WriteLine( e.StackTrace.ToString());
            }*/

            
            
            driver.Quit();
        }
    }
}
