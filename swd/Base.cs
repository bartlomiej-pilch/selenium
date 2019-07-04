using NUnit.Framework;
using OpenQA.Selenium;

namespace swd
{
    [TestFixture]

    public class Base
    {
        public IWebDriver driver { get; set; }
    }
}
