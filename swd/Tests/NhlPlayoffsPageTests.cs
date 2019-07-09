using NUnit.Framework;
using swd.PageObjects;
using System;

namespace swd.Tests
{
    public class NhlPlayoffsPageTests
    {
        [Test]
        [Parallelizable]
        [Category("FirefoxOnly")]
        public void shouldNavigateToPlayoffsPageFirefox()
        {
            executeTest(BrowserType.FF);
        }

        [Test]
        [Parallelizable]
        [Category("ChromeOnly")]
        public void shouldNavigateToPlayoffsPageChrome()
        {
            executeTest(BrowserType.Chrome);
        }


        public void executeTest(BrowserType browserType)
        {
            NhlMainPage nhlMainPage = new NhlMainPage(browserType);
            nhlMainPage.NavigateToNhlMainPage();

            NhlPlayoffsPage nhlPlayoffsPage = nhlMainPage.GoToPlayoffsPage();

            String expectedTitleForPlayoffPage = "Stanley Cup Playoffs | NHL.com";
            nhlPlayoffsPage.Assertion(nhlPlayoffsPage.Title, expectedTitleForPlayoffPage);

        }
    }

}
