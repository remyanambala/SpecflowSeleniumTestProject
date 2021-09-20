using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RegressionTestSuite.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RegressionTestSuite.PageObjects
{
    public class JavaScriptHomePage: BaseClass
    {
        #region WebElements
        IWebElement Header => Driver.FindElement(By.XPath("//div[@class='example']/h3"));
        By ByHeader => By.XPath("//div[@class='example']/h3");
        IWebElement JSAlertBtn => Driver.FindElement(By.XPath("//button[@onclick='jsAlert()']"));
           
        IWebElement JSConfirmBtn =>Driver.FindElement(By.XPath("//button[@onclick='jsConfirm()']"));
        IWebElement JSPromptBtn => Driver.FindElement(By.XPath("//button[@onclick='jsPrompt()']"));
      
        IWebElement ResultText => Driver.FindElement(By.Id("result"));

        #endregion WebElements

 
        public IAlert JSAlert { get; set; }
   
        public string URL { get; private set; }
        public bool IsPageLoaded
        {
            get
            {
                try
                {
                    bool isLoaded;
                    //Check that header is loaded
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ByHeader));
                    isLoaded = Header.Text.Contains("JavaScript Alerts");
                    return isLoaded;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
        public JavaScriptHomePage(IWebDriver driver): base(driver)
        {
            URL = TestObjects.Config.GetJavaScriptAlertURL();
        }
              


        //common methods - This is applicable for all kind of alerts
        internal void ClickOKOnJSAlertPopUps()
        {
            JSAlert.Accept();
        }

        internal void CheckJsAlertPopUpsIsClosed()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertState(false));
        }

        internal void ClickCancelOnJSAlertPopUps()
        {
            JSAlert.Dismiss();
        }
        //common methods - end

        internal void CheckJsAlert()
        {
            String expectedAlertMsg = "I am a JS Alert";
            JSAlert = Driver.SwitchTo().Alert();
            Assert.AreEqual(expectedAlertMsg, JSAlert.Text, "Alert message is not correct");
        }

        internal void CheckJsConfirm()
        {
            String expectedAlertMsg = "I am a JS Confirm";
            JSAlert = Driver.SwitchTo().Alert();
            Assert.AreEqual(expectedAlertMsg, JSAlert.Text, "Alert message is not correct");
        }

        internal void CheckJsPrompt()
        {
            String expectedAlertMsg = "I am a JS prompt";
            JSAlert = Driver.SwitchTo().Alert();
            Assert.AreEqual(expectedAlertMsg, JSAlert.Text, "Alert message is not correct");
        }


        internal void CheckMessage(string expectedMessage)
        {
            Assert.AreEqual(expectedMessage, ResultText.Text, "Result message is not correct");
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl(URL);
        }

        internal void ClickOnJSAlert()
        {
          JSAlertBtn.Click();
          Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        internal void ClickOnJSConfirm()
        {
            JSConfirmBtn.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }
        internal void ClickOnJSPrompt()
        {
            JSPromptBtn.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        internal void EnterTextOnJSPrompt(string text)
        {
            JSAlert.SendKeys(text);
        }

    }
}
