using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DelivermoreUITests
{
    public class NotLoggedInPage : PageBase
    {

        public NotLoggedInPage(IWebDriver webDriver) : base(webDriver)
        {
            
        }

        [FindsBy(How = How.Id, Using = "registerLink")]
        public IWebElement RegisterLink { get; set; }
    }
}
