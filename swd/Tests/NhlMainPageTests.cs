using NUnit.Framework;
using swd.PageObjects;
using System;

namespace swd.Tests
{
    public class NhlMainPageTests
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

