using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace RegressionTestSuite.PageObjects
{
    public class AddNewComputerPage: BaseClass
    {
        #region WebElements
        IWebElement Header => Driver.FindElement(By.XPath("//section[@id='main']/h1"));
        IWebElement ComputerName => Driver.FindElement(By.Id("name"));
        IWebElement ComputerNameFieldMsg => Driver.FindElement(By.XPath("//fieldSet/div[1]//span"));
        IWebElement Introduced => Driver.FindElement(By.Id("introduced"));
        IWebElement IntroducedFieldMsg => Driver.FindElement(By.XPath("//fieldSet/div[2]//span"));
        IWebElement Discontinued => Driver.FindElement(By.Id("discontinued"));
        IWebElement DiscontinuedFieldMsg => Driver.FindElement(By.XPath("//fieldSet/div[3]//span"));
        IWebElement Company => Driver.FindElement(By.Id("company"));
        IWebElement CreateBtn => Driver.FindElement(By.XPath("//input[@class='btn primary']"));
        By ByCreateBtn => By.XPath("//input[@class='btn primary']");

        #endregion WebElements
     
        public bool IsPageLoaded
        {
            get
            {
                try
                {
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ByCreateBtn));
                    bool isLoaded = Header.Text.Contains("Add a computer");
                    return isLoaded;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                
            }
        }
        public AddNewComputerPage(IWebDriver driver) : base(driver) { }
                      

        internal void FillAddNewComputerForm(string computerName, string introduced, string discontinued, string company)
        {
            
                ComputerName.SendKeys(computerName);
                Introduced.SendKeys(introduced);
                Discontinued.SendKeys(discontinued);
                SelectElement dropDownCompany = new SelectElement(Company);
                dropDownCompany.SelectByText(company);
           
        }

      
        internal bool AreFillFormFieldsDisplayed()
        {
            try
            {
                if (ComputerName.Displayed && ComputerName.Enabled &&
                    Introduced.Displayed && Introduced.Enabled &&
                    Discontinued.Displayed && Introduced.Enabled &&
                    Company.Displayed && Company.Enabled)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

       
        internal void CheckErrorForComputerNameBeingUnfilled()
        {
           
                string expectedErrorMsg = "Failed to refine type : Predicate isEmpty() did not fail.";
                Assert.AreEqual(expectedErrorMsg, ComputerNameFieldMsg.Text, "Error message for missing computer name is incorrect");
            
           
        }

        internal void CheckErrorForInvalidDiscontinuedDate(string message)
        {
            
                string expectedErrorMsg = message;
                Assert.AreEqual(expectedErrorMsg, DiscontinuedFieldMsg.Text, "Error message for missing computer name is incorrect");
                       
        }

        internal void CheckErrorForInvalidIntroducedDate(string message)
        {
           
                string expectedErrorMsg = message;
                Assert.AreEqual(expectedErrorMsg, IntroducedFieldMsg.Text, "Error message for missing computer name is incorrect");
                    
        }

        internal ComputerDBHomePage SubmitCreate()
        {
          
                CreateBtn.Click();
                return new ComputerDBHomePage(Driver);
                      
        }

    }
}
