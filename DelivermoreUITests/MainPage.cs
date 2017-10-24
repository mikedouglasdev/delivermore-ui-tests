using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DelivermoreUITests
{
    public class MainPage : LoggedInPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='activies']/div/table/tbody/tr[1]/td[1]/div/label")]
        private IWebElement LoseWeightlabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='activies']/div/table/tbody/tr[2]/td[1]/div/label")]
        private IWebElement BeMoreActiveLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='activies']/div/table/tbody/tr[3]/td[1]/div/label")]
        private IWebElement GetStrongerLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='activies']/div/table/tbody/tr[4]/td[1]/div/label")]
        private IWebElement GetFasterLabel { get; set; }

        public Boolean LoseWeight
        {
            get
            {
                OpenQA.Selenium.Remote.RemoteWebDriver wd = (OpenQA.Selenium.Remote.RemoteWebDriver)WebDriver;
                IWebElement e =  wd.FindElementById("GoalChkBox+1");

                return (e.Selected);
            }
            set
            {
                OpenQA.Selenium.Remote.RemoteWebDriver wd = (OpenQA.Selenium.Remote.RemoteWebDriver)WebDriver;
                IWebElement e = wd.FindElementById("GoalChkBox+1");

                if (e.Selected != value)
                {
                    // Set the value of the control by clicking on it's label element. 
                    LoseWeightlabel.Click();
                }
            }
        }

        public Boolean BeMoreActive
        {
            get
            {
                OpenQA.Selenium.Remote.RemoteWebDriver wd = (OpenQA.Selenium.Remote.RemoteWebDriver)WebDriver;
                IWebElement e = wd.FindElementById("GoalChkBox+2");

                return (e.Selected);
            }
            set
            {
                OpenQA.Selenium.Remote.RemoteWebDriver wd = (OpenQA.Selenium.Remote.RemoteWebDriver)WebDriver;
                IWebElement e = wd.FindElementById("GoalChkBox+2");

                if (e.Selected != value)
                {
                    // Set the value of the control by clicking on it's label element. 
                    BeMoreActiveLabel.Click();
                }
            }
        }

        public Boolean GetStronger
        {
            get
            {
                OpenQA.Selenium.Remote.RemoteWebDriver wd = (OpenQA.Selenium.Remote.RemoteWebDriver)WebDriver;
                IWebElement e = wd.FindElementById("GoalChkBox+3");

                return (e.Selected);
            }
            set
            {
                OpenQA.Selenium.Remote.RemoteWebDriver wd = (OpenQA.Selenium.Remote.RemoteWebDriver)WebDriver;
                IWebElement e = wd.FindElementById("GoalChkBox+3");

                if (e.Selected != value)
                {
                    // Set the value of the control by clicking on it's label element. 
                    GetStrongerLabel.Click();
                }
            }
        }

        public Boolean GetFaster
        {
            get
            {
                OpenQA.Selenium.Remote.RemoteWebDriver wd = (OpenQA.Selenium.Remote.RemoteWebDriver)WebDriver;
                IWebElement e = wd.FindElementById("GoalChkBox+4");

                return (e.Selected);
            }
            set
            {
                OpenQA.Selenium.Remote.RemoteWebDriver wd = (OpenQA.Selenium.Remote.RemoteWebDriver)WebDriver;
                IWebElement e = wd.FindElementById("GoalChkBox+4");

                if (e.Selected != value)
                {
                    // Set the value of the control by clicking on it's label element. 
                    GetFasterLabel.Click();
                }
            }
        }

        public MainPage(IWebDriver webDriver) : base(webDriver)
        {
            Title = "Home Page";
            Url = "/";
        }

        public bool IsAt()
        {
            return Browser.Title == Title;

        }
    }
}
