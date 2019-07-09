using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using swd.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swd.PageObjects
{
    public class NhlMainPage : BasePage
    {


        public NhlMainPage(BrowserType browserType) : base(browserType)
        {

        }

        public void NavigateToNhlMainPage()
        {
            String url = "http://nhl.com";
            Console.WriteLine("Opening page: " + url);
            Driver.Navigate().GoToUrl(url);
            String expectedText = "Official Site of the National Hockey League | NHL.com";
            waitForTitleTextInPageDOM(10, expectedText);
            Console.WriteLine("Page: " + url + " opened!");
        }

        public NhlPlayoffsPage GoToPlayoffsPage()
        {
            playoffsLocator.Click();
            String expectedTitleForPlayoffPage = "Stanley Cup Playoffs | NHL.com";
            waitForTitleTextInPageDOM(10, expectedTitleForPlayoffPage);
            return new NhlPlayoffsPage(Driver);
        }
    }


}
