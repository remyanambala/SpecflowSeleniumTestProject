using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RegressionTestSuite.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;


namespace RegressionTestSuite.PageObjects
{
    public class BaseClass
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

       
        public BaseClass(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
