using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelivermoreUITests
{
    [TestClass]
    public class UserTests
    {
        private TestContext _testContextInstance;
        private string _url = "http://delivermorermtest.azurewebsites.net/";
        private string _browser = "IE";

        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.Properties.Contains("environment"))
            {
                string environment = TestContext.Properties["environment"].ToString();
                _url = "http://delivermorermtest.azurewebsites.net/";
            }

            if (TestContext.Properties.Contains("browser"))
            {
                _browser = TestContext.Properties["browser"].ToString();
            }
        }

        [TestMethod]
        public void ValidUserCanLogonAndLogOff()
        {

            var driver = Browser.Open(_url, _browser);

            LoginPage loginPage = new LoginPage(driver);

            loginPage.Logon("abc@abc.com", "P@ssw0rd").Logoff();
            Browser.Close();
        }


        [TestMethod]
        public void CanRegisterNewUserAndLogoff()
        {
            string user = UniqueUserName;

            var driver = Browser.Open(_url, _browser);
            LoginPage loginPage = new LoginPage(driver);

            loginPage.RegisterLink.Click();

            RegisterPage registerPage = new RegisterPage(driver);

            Assert.IsTrue(registerPage.IsAt());

            MainPage mp = registerPage.RegisterNewUser(user, "P@ssw0rd", "P@ssw0rd");

            Assert.IsTrue(mp.IsAt());

            mp.Logoff();

         }

        [TestMethod]
        public void LoginFailWithInvalidCredentials()
        {

            var driver = Browser.Open(_url, _browser);

            LoginPage loginPage = new LoginPage(driver);

            loginPage.Logon("abc@abc.com", "invalidP@ssw0rd");

            Assert.IsTrue(loginPage.LoginErrorMessage.Text == "Invalid login attempt.");
        }

        [TestMethod]
        public void LoginFailWithBlankEmail()
        {

            var driver = Browser.Open(_url, _browser);

            LoginPage loginPage = new LoginPage(driver);

            loginPage.Logon("", "invalidP@ssw0rd");

            Assert.IsTrue(loginPage.EmailValidationErrorMessage == "'Email' has already been used.");
        }


        [TestMethod]
        public void LoginFailWithBlankPassword()
        {

            var driver = Browser.Open(_url, _browser);

            LoginPage loginPage = new LoginPage(driver);

            loginPage.Logon("abc@abc.com", "");

            Assert.IsTrue(loginPage.PasswordValidationErrorMessage == "The Password field is required.");
        }


        [TestMethod]
        public void LoginFailWithNoCredentials()
        {

            var driver = Browser.Open(_url, _browser);

            LoginPage loginPage = new LoginPage(driver);

            loginPage.Logon("", "");

            Assert.IsTrue(loginPage.IsAt());
        }


        [TestMethod]
        public void CanSetGoals()
        {

            var driver = Browser.Open(_url, _browser);

            LoginPage loginPage = new LoginPage(driver);

            MainPage mp = loginPage.Logon("abc@abc.com", "P@ssw0rd");

            // Set checkboxes
            mp.LoseWeight = true;
            mp.BeMoreActive = true;
            mp.GetStronger = false;
            mp.GetFaster = true;

            Assert.IsTrue(mp.LoseWeight);
            Assert.IsTrue(mp.BeMoreActive);
            Assert.IsFalse(mp.GetStronger);
            Assert.IsTrue(mp.GetFaster);
        }


        public TestContext TestContext
        {
            get
            {
                return _testContextInstance;
            }
            set
            {
                _testContextInstance = value;
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Browser.Quit();
        }
        private string UniqueUserName
        {
            get { return "user_" + Guid.NewGuid().ToString() + "@test.com"; }
        }

    }
}
