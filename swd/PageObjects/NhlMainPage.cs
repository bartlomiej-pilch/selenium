using OpenQA.Selenium;
using swd.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swd
{
    public class NhlMainPage : Page
    {
        public NhlMainPage(IWebDriver driver) : base(driver)
        {
        }

        By playoffsLocator = By.XPath("//a[text()='Playoffs']");

        public PlayoffsPage GoToPlayoffsPage()
        {
            click(playoffsLocator);
            return new PlayoffsPage(driver);
        }
    }


}
