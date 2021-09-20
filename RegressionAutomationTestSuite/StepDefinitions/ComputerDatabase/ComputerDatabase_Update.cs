using RegressionTestSuite.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RegressionTestSuite.StepDefinitions.ComputerDatabase
{
    [Binding]
    public sealed class ComputerDatabase_Update
    {
        [When(@"user updates values for fields ""(.*)"", ""(.*)"", ""(.*)"" , ""(.*)""")]
        public void WhenUserUpdatesValuesForFields(string computerName, string introduced, string discontinued, string company)
        {
            TestObjects.editPage.UpdateComputerDetails(computerName, introduced, discontinued, company);
        }

        [When(@"click on Save this computer button")]
        public void WhenClickOnSaveThisComputerButton()
        {
            TestObjects.compDBHomePage = TestObjects.editPage.ClickSaveBtn();
        }


    }
}
