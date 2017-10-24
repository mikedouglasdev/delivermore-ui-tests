using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace DelivermoreUITests
{
    public static class Pages
    {
        public static LoginPage2 LoginPage
        {
            get
            {
                var loginPage = new LoginPage2();
                PageFactory.InitElements(Browser.Driver, loginPage);
                return loginPage;
            }
        }
    }
}
