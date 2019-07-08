//using NUnit.Framework;
//using swd.PageObjects;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace swd.Tests
//{
//    public class NhlPlayoffsPageTestsFiregox : FirefoxTesting
//    {
//        [Test]
//        public void shouldNavigateToPlayoffsPageFirefox()
//        {
//            NhlMainPage nhlMainPage = new NhlMainPage(BrowserType.Chrome);
//            nhlMainPage.NavigateToNhlMainPage();
//            NhlPlayoffsPage nhlPlayoffsPage = new NhlPlayoffsPage(driver);
//            nhlMainPage.GoToPlayoffsPage();

//            String expectedTitleForPlayoffPage = "Stanley Cup Playoffs | NHL.com";
//            nhlPlayoffsPage.Assertion(nhlMainPage.Title, expectedTitleForPlayoffPage);
//        }

//    }
//    //public class NhlPlayoffsPageTestsChrome : ChromeTesting
//    //{
//    //    [Test]
//    //    public void shouldNavigateToPlayoffsPageChrome()
//    //    {
//    //        NhlMainPage nhlMainPage = new NhlMainPage(driver);
//    //        nhlMainPage.NavigateToNhlMainPage();

//    //        NhlPlayoffsPage nhlPlayoffsPage = nhlMainPage.GoToPlayoffsPage();

//    //        String expectedTitleForPlayoffPage = "Stanley Cup Playoffs | NHL.com";
//    //        nhlPlayoffsPage.Assertion(driver.Title, expectedTitleForPlayoffPage);
//    //    }
//    //}
//}
