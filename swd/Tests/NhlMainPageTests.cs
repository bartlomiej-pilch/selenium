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

namespace swd.Tests
{
    public class NhlMainPageTestsFirefox
    {
        [Test]
        [Parallelizable]
        [Category("FirefoxOnly")]
        public void shouldNavigateToNhlMainPageFirefox()
        {
            NavigateToMainPage(BrowserType.FF);
        }

        [Test]
        [Parallelizable]
        [Category("ChromeOnly")]
        public void shouldNavigateToNhlMainPageChrome()
        {
            NavigateToMainPage(BrowserType.Chrome);
        }

        private void NavigateToMainPage(BrowserType browserType)
        {
            NhlMainPage nhlMainPage = new NhlMainPage(browserType);
            nhlMainPage.NavigateToNhlMainPage();

            String expectedText = "Official Site of the National Hockey League | NHL.com";
            nhlMainPage.Assertion(nhlMainPage.Title, expectedText);
        }
    }
}

