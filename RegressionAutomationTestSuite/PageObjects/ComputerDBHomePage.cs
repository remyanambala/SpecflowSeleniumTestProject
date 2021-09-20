using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using RegressionTestSuite.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressionTestSuite.PageObjects
{
    public class ComputerDBHomePage: BaseClass
    {
        #region WebElements
        IWebElement AddComputerBtn => Driver.FindElement(By.Id("add"));
        IWebElement Header => Driver.FindElement(By.XPath("//section[@id='main']/h1"));
        IWebElement alertMsg => Driver.FindElement(By.XPath("//div[@class='alert-message warning']"));
        IWebElement filterTextBox => Driver.FindElement(By.Id("searchbox"));
        IWebElement filterButton => Driver.FindElement(By.Id("searchsubmit"));
        IList<IWebElement> computerGrid => Driver.FindElements(By.XPath("//table[@class='computers zebra-striped']"));
        IList<IWebElement> computerRecordsList => Driver.FindElements(By.XPath("//table[@class='computers zebra-striped']/tbody/tr"));

        IWebElement NoComputerFoundTxt => Driver.FindElement(By.XPath("//div[@class='well']/em"));

        By ByAddComputerBtn => By.Id("add");

        //Below is used to find the record link to be clicked for a particular computer record row in record grid list 
        By ByComputerRecordViewLink => By.XPath("//*/td/a");

        #endregion WebElements


        public string URL { get; set; }
        public bool IsPageLoaded
        {
            get
            {
                try
                {
                    bool isLoaded;
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ByAddComputerBtn));
                    isLoaded = Header.Text.Contains("computers found");
                    return isLoaded;
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        internal void CheckNoComputerRecordFound()
        {
            string expectedMsg = "Nothing to display";
            Assert.AreEqual(expectedMsg, NoComputerFoundTxt.Text, "Message incorrect when computers are not found");
            //No computers in grid
            Assert.IsFalse(IsSearchedComputerFound());
        }

        public ComputerDBHomePage(IWebDriver driver): base(driver)
        {
           URL = TestObjects.Config.GetComputerDBURL();
        }

    
        internal void GoTo()
        {
           Driver.Navigate().GoToUrl(URL) ;

        }
             

        internal bool IsAddNewBtnVisible()
        {

            try
            {
                return (AddComputerBtn.Displayed && AddComputerBtn.Enabled);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
            
           
        }

      
        internal bool VerifyMessageDisplayed(string message)
        {
            try
            {
                string msg = alertMsg.Text;
                return msg.Equals(message);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        internal bool EnterFilterText(string searchText)
        {

            try
            {
                filterTextBox.SendKeys(searchText);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
            
        }
        internal bool ClickOnFilterBtn()
        {
            try
            {
                filterButton.Click();
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }     

        }

        internal bool IsSearchedComputerFound()
        {
            //if the grid is present and has records (count >0),search has returned results. Else none found.
            if (computerGrid.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        internal AddNewComputerPage ClickOnAddNewComputerButton()
        {
            
                AddComputerBtn.Click();
                return new AddNewComputerPage(Driver);
           
        }


        internal EditComputerPage ClickOnComputerRecord(int row)
        {
            //actual row number in list
            int recordRow = row - 1;

            IWebElement recordLink = computerRecordsList[recordRow].FindElement(ByComputerRecordViewLink);
            recordLink.Click();
            return new EditComputerPage(Driver);
        }

    }
}
