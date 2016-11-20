using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Reflection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace DelivermoreUITests
{
    public static class Browser
    {
        private static IWebDriver WebDriver;
     
        internal static void Close()
        {
            WebDriver.Close();
        }

        internal static ISearchContext Driver
        {
            get { return WebDriver; }
        }

        public static void Navigate(string url)
        {
            WebDriver.Url = url;
        }

        internal static WebDriverWait Wait()
        {
            return new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30));
        }

        public static IWebDriver Open(string url, string browserName)
        {
            DesiredCapabilities capability = new DesiredCapabilities();
            capability.SetCapability("browserName", browserName);
            Uri server = new Uri(url);
            if (browserName == "chrome")
            {
                WebDriver = new ChromeDriver();
            }
            else
            {
                WebDriver = new InternetExplorerDriver();
            }
            WebDriver.Navigate().GoToUrl(server);

            WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));

            MaximizeWindow();

            return WebDriver;
    }

        internal static void MaximizeWindow()
        {
            WebDriver.Manage().Window.Maximize();
        }

        public static void Quit()
        {
            WebDriver.Quit();
        }

    }
}
