using Microsoft.Edge.SeleniumTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressionTestSuite.Resources
{
       public static class DriverCreator
    {
        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }
       
         private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            return option;
        }

           
        public static void InitWebdriver()
        {
            TestObjects.Config = new AppConfigReader();


            switch (TestObjects.Config.GetBrowser())
            {
                case BrowserTypes.Chrome:
                    TestObjects.Driver = GetChromeDriver();
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException("No such browser exists");

            }
        }

       

        public static void TearDown()
        {
            if(TestObjects.Driver != null)
            {
                TestObjects.Driver.Quit();
            }
        }

    }
}
