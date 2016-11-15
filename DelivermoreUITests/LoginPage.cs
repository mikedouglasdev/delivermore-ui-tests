using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DelivermoreUITests
{
    public class LoginPage : NotLoggedInPage
    {
        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn-default")]
        public IWebElement LoginButton { get; set; }

        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
            Title = "Log in";
            Url = "/Account/Login";
        }

        public MainPage Logon(string userName, string password)
        {
            WaitForLoad();

            Username.Clear();
            Username.SendKeys(userName);

            Password.Clear();
            Password.SendKeys(password);

            LoginButton.Click();

            return new MainPage(WebDriver);
        }
    }
}
