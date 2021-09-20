using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegressionTestSuite.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RegressionTestSuite.StepDefinitions.ComputerDatabase
{
    [Binding]
    public sealed class ComputerDatabase_View
    {
        #region When
       
       
        [When(@"user click on Cancel button")]
        public void WhenUserClickOnCancelButton()
        {
            TestObjects.compDBHomePage = TestObjects.editPage.ClickCancelBtn();
        }


        #endregion When

        #region Then
        

        [Then(@"correct values for fields ""(.*)"", ""(.*)"", ""(.*)"" , ""(.*)"" are displayed")]
        public void ThenCorrectValuesForFieldsAreDisplayed(string computerName, string introduced, string discontinued, string company)
        {
            Assert.IsTrue(TestObjects.editPage.AreCorrectComputerDetailsDisplayed(computerName, introduced, discontinued, company), "Corect computer details are not displayed");
               
        }

        [Then(@"text Nothing to display is seen and no computer records are seen")]
        public void ThenTextNothingToDisplayIsSeenAndNoComputerRecordsAreSeen()
        {
            TestObjects.compDBHomePage.CheckNoComputerRecordFound();
        }



        #endregion Then


    }
}
