using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DelivermoreUITests
{
    public class MainPage : LoggedInPage
    {
        public MainPage(IWebDriver webDriver) : base(webDriver)
        {
            Title = "Home Page";
            Url = "/";
        }
    }
}
