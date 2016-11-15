using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DelivermoreUITests
{
    public abstract class PageBase
    {
        internal static string Title { get; set; }
        internal static string Url { get; set; }
        internal static IWebDriver WebDriver { get; set; }

        protected PageBase(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
            Url = "";
            Title = "";
        }
        protected PageBase(string url, string title)
        {
            Url = url;
            Title = title;
        }

        internal void WaitForLoad()
        {
            var wait = Browser.Wait();

            try
            {
                wait.Until(p => p.Title == Title);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                TakeScreenshot();
                throw;
            }

        }

        internal static void WaitFor(By elementDescription)

        {

            var wait = Browser.Wait();



            wait.Until(e => e.FindElement(elementDescription));

        }


        internal void TakeScreenshot()
        {
            string captureLocation = "c:\\temp\\testresults\\";
            string callingMethodName = new StackFrame(1, true).GetMethod().Name;
            string callingClassName = GetType().Name;
            string timeStamp = DateTime.Now.ToString("ddMMyyyyHHmmss");

            string filePath = captureLocation + callingMethodName + "ErrorCapture" + timeStamp + ".png";



            try

            {

                //TODO : Add more info to the filename and suitable location to save to 

                Screenshot ss = ((ITakesScreenshot)Browser.Driver).GetScreenshot();

                ss.SaveAsFile(filePath, ImageFormat.Png);

            }

            catch (Exception e)

            {

                Console.WriteLine("TakeScreenshot encountered an error. " + e.Message);

                throw;

            }



            Console.WriteLine(callingClassName + "." + callingMethodName + " generated an error. A ScreenShot of the browser has been saved. " + filePath);

        }
    }
}
