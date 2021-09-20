using RegressionTestSuite.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RegressionTestSuite.StepDefinitions.ComputerDatabase
{
    [Binding]
    public sealed class ComputerDatabase_Delete
    {
        [When(@"user clicks on Delete this computer button")]
        public void WhenUserClicksOnDeleteThisComputerButton()
        {
            TestObjects.compDBHomePage = TestObjects.editPage.ClickDeleteBtn();
        }

    }
}
