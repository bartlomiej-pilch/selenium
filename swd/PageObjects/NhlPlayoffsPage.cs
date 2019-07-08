using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace swd.PageObjects
{
    public class NhlPlayoffsPage : BasePage
    {
        public NhlPlayoffsPage(IWebDriver driver) : base(driver)
        {
        }

        public NhlPlayoffsPage(BrowserType browserType) : base(browserType)
        {
        }

        public void waitForPlayoffsButtonToBeClickable()
        {
            waitForElementToBeVisible(10, playoffsLocator);
        }

    }
}
