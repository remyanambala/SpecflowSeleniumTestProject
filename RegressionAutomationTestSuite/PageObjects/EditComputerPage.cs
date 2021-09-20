using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressionTestSuite.PageObjects
{
    public class EditComputerPage : BaseClass
    {
        #region WebElements
        IWebElement Header => Driver.FindElement(By.XPath("//section[@id='main']/h1"));
        IWebElement ComputerName => Driver.FindElement(By.Id("name"));
        IWebElement Introduced => Driver.FindElement(By.Id("introduced"));
        IWebElement Discontinued => Driver.FindElement(By.Id("discontinued"));
        IWebElement Company => Driver.FindElement(By.Id("company"));
        IWebElement SubmitBtn => Driver.FindElement(By.XPath("//input[@class='btn primary']"));
        IWebElement CancelBtn => Driver.FindElement(By.XPath("//a[@class='btn']"));
        IWebElement DeleteBtn => Driver.FindElement(By.XPath("//input[@class='btn danger']"));
        By BySubmitBtn => By.XPath("//input[@class='btn primary']");

        #endregion WebElements

        public bool IsPageLoaded
        {
            get
            {
                try
                {
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(BySubmitBtn));
                    bool isLoaded = Header.Text.Contains("Edit computer");
                    return isLoaded;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public EditComputerPage(IWebDriver driver): base(driver) { }
       
       

        internal bool AreCorrectComputerDetailsDisplayed(string computerName, string introduced, string discontinued, string company)
        {
            try
            {
                SelectElement dropDownCompany = new SelectElement(Company);


                if (ComputerName.GetAttribute("value").Equals(computerName) &&
                    Introduced.GetAttribute("value").Equals(introduced) &&
                    Discontinued.GetAttribute("value").Equals(discontinued) &&
                    dropDownCompany.SelectedOption.Text.Equals(company))
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

        internal void UpdateComputerDetails(string computerName, string introduced, string discontinued, string company)
        {
            //Getting a value of NA means that specific field needn't be updated
            //Restricting blank value for computer name as it can't be saved
            if (!computerName.Equals("NA") && !computerName.Equals(""))
            {
                ComputerName.Clear();
                ComputerName.SendKeys(computerName);
            }
            if (!introduced.Equals("NA"))
            {
                Introduced.Clear();
                Introduced.SendKeys(introduced);
            }
            if (!discontinued.Equals("NA"))
            {
                Discontinued.Clear();
                Discontinued.SendKeys(discontinued);
            }
            if (!company.Equals("NA"))
            {
                SelectElement dropDownCompany = new SelectElement(Company);
                dropDownCompany.SelectByText(company);
            }
        }

        internal ComputerDBHomePage ClickCancelBtn()
        {
            CancelBtn.Click();
            return new ComputerDBHomePage(Driver);
        }

        internal ComputerDBHomePage ClickSaveBtn()
        {
            SubmitBtn.Click();
             return new ComputerDBHomePage(Driver);
        }

        internal ComputerDBHomePage ClickDeleteBtn()
        {
            DeleteBtn.Click();
            return new ComputerDBHomePage(Driver);
        }
    }
}
