using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace swd
{
    public enum BrowserType
    {
        Chrome,
        FF
    } 

    [TestFixture]
    public class Hooks:Base
    {
        private BrowserType _browserType;
        public Hooks(BrowserType browserType)
        {
            _browserType = browserType;
        }

        [SetUp] 
        public void InitializeTest()
        {
            if (_browserType == BrowserType.Chrome) { driver = new ChromeDriver(); }
            else if (_browserType == BrowserType.FF) { driver = new FirefoxDriver(); }
        }

        [TearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
    }
}
