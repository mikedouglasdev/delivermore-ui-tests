using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DelivermoreUITests
{
    public class LoggedInPage : PageBase
    {
        public LoggedInPage(IWebDriver webDriver) : base(webDriver)
        {
            
        }

        [FindsBy(How = How.LinkText, Using = "Log off")]
        public IWebElement LogOff { get; set; }

        public LoginPage Logoff()
        {
            LogOff.Click();

            return new LoginPage(WebDriver);
            
        }
    }
}
