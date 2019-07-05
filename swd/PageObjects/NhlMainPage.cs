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

        By playoffsLocator = By.XPath("//a[text()='Playoffs']");

        public NhlMainPage(IWebDriver driver) : base(driver)
        {
        }

        public PlayoffsPage GoToPlayoffsPage()
        {
            Click(driver,playoffsLocator);
            return new PlayoffsPage(driver);
        }
    }


}
