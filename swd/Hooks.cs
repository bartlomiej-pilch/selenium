using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swd
{
    public class Hooks:Base
    {
        public Hooks()
        {
            driver = new FirefoxDriver();
        }
    }
}
