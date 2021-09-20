using OpenQA.Selenium;
using RegressionTestSuite.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressionTestSuite.Resources
{
    public static class TestObjects
    {
        public static IWebDriver Driver { get; set; }
        public static AppConfigReader Config { get; set; }

        //Declaring objects here as static so that they are accessible across all step definition files
        public static ComputerDBHomePage compDBHomePage;
        public static AddNewComputerPage addNewPage;
        public static EditComputerPage editPage;
        public static JavaScriptHomePage jsAlertPage;


    }
}
