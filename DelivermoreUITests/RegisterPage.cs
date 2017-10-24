using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DelivermoreUITests
{
    public class RegisterPage : NotLoggedInPage
    {
        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn-default")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        public IWebElement ConfirmPassword { get; set; }

        public RegisterPage(IWebDriver webDriver) : base(webDriver)
        {
            Title = "Register";
            Url = "/Account/Register";
        }

        public MainPage RegisterNewUser(string userName, string password, string confirmPassword)
        {
            WaitForLoad();

            Username.Clear();
            Username.SendKeys(userName);

            Password.Clear();
            Password.SendKeys(password);

            ConfirmPassword.Clear();
            ConfirmPassword.SendKeys(confirmPassword);

            LoginButton.Click();

            return new MainPage(WebDriver);
        }

        public bool IsAt()
        {
            return Browser.Title == Title;
        
        }
    }
}
