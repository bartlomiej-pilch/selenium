using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            IWebElement searchField = driver.FindElement(By.XPath("//input[@type='text']"));
            searchField.SendKeys("chuju"+Keys.Enter);

            IWebElement results = driver.FindElement(By.Id("resultStats"));

            String pageSource = driver.PageSource.ToString();

            Assert.AreEqual(results.Displayed, true);
            Assert.True(results.Displayed);
            Assert.True(pageSource.Contains("chuju - Szukaj w Google"));

            /*try
            {
                Assert.IsFalse(results.Displayed, "google search gone wrong");
            } catch (AssertionException a) { System.Console.Out.WriteLine(a.StackTrace.ToString()); }
            */

            try
            {
                Thread.Sleep(2000);
            }
            catch (ThreadInterruptedException e)
            {
                System.Console.Out.WriteLine( e.StackTrace.ToString());
            }
            
            driver.Quit();
        }
    }
}
