using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelivermoreUITests
{
    [TestClass]
    public class UserTests
    {
        private TestContext _testContextInstance;
        private string _url = "http://delivermorermtest.azurewebsites.net/";
        private string _browser = "chrome";

        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.Properties.Contains("environment"))
            {
                string environment = TestContext.Properties["environment"].ToString();
                _url = environment == "Test" ? "http://delivermorermtest.azurewebsites.net/" : "http://delivermorermprod.azurewebsites.net/";
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

            loginPage.Logon(" ", "P@ssw0rd").Logoff();

            Browser.Close();
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
    }
}
