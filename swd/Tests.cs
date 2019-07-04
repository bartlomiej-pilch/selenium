using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using swd.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace swd
{
    [TestFixture]
    [Parallelizable]
    [Category("FirefoxOnly")]
    public class FirefoxTesting : Hooks
    {
        public FirefoxTesting() : base(BrowserType.FF)
        {

        }

        //[Test]
        public void osomTest()
        {
            //IWebDriver driver = new ChromeDriver();
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

        [Test]
        public void jsTricksTest()
        {
            //IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://nhl.com");

            //
            //wait setup
            TimeSpan span = new TimeSpan(0, 0, 10);
            WebDriverWait wait = new WebDriverWait(driver, span);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleContains("Official Site of the National Hockey League | NHL.com"));

            Debug.WriteLine("NHL main page opened biatch!");

            Assert.AreEqual(driver.Title, "Official Site of the National Hockey League | NHL.com");

            //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;


            driver.Quit();
        }
    }

    [TestFixture]
    [Parallelizable]
    [Category("ChromeOnly")]
    public class ChromeTesting : Hooks
    {
        public ChromeTesting() : base(BrowserType.Chrome)
        {
        }

        [Test]
        public void nhlMainPageTest()
        {

            Page page = new Page(driver);
            NhlMainPage nhlMainPage = page.NavigateToNhlMainPage();

            String expectedText = "Official Site of the National Hockey League | NHL.com";
            nhlMainPage.waitForTitleTextInPageDOM(10, expectedText);

            nhlMainPage.Assertion(driver.Title, expectedText);

            PlayoffsPage playoffsPage = nhlMainPage.GoToPlayoffsPage();

            String expectedTitleForPlayoffPage = "Stanley Cup Playoffs | NHL.com";
            playoffsPage.waitForTitleTextInPageDOM(10, expectedTitleForPlayoffPage);

            playoffsPage.Assertion(driver.Title, expectedTitleForPlayoffPage);



        }
    }
}
