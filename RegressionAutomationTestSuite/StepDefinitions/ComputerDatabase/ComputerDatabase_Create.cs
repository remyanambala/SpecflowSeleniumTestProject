using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegressionTestSuite.PageObjects;
using RegressionTestSuite.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RegressionTestSuite.StepDefinitions.ComputerDatabase
{
    [Binding]
    public sealed class ComputerDatabase_Create
    {
      
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public ComputerDatabase_Create(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

      
        #region When
        [When(@"user click on Add a new Computer button")]
        public void WhenUserClickOnAddANewComputerButton()
        {
            TestObjects.addNewPage = TestObjects.compDBHomePage.ClickOnAddNewComputerButton();
        }

        [When(@"user enters values for ""(.*)"", ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void WhenUserEntersValuesForAnd(string computerName, string Introduced, string Discontinued, string Company)
        {
            TestObjects.addNewPage.FillAddNewComputerForm(computerName, Introduced, Discontinued, Company);
        }
        [When(@"click on Create this computer button")]
        public void WhenClickOnCreateThisComputerButton()
        {
            TestObjects.compDBHomePage = TestObjects.addNewPage.SubmitCreate();
            
        }

        #endregion


        #region Then

        [Then(@"Add a computer page is displayed")]
        public void ThenAddAComputerPageIsDisplayed()
        {
            Assert.IsTrue(TestObjects.addNewPage.IsPageLoaded, "Add new computer page is not loaded");
        }
        [Then(@"fields Computer name, Introduced, Discontinued and Company are displayed")]
        public void ThenFieldsComputerNameIntroducedDiscontinuedAndCompanyAreDisplayed()
        {
            Assert.IsTrue(TestObjects.addNewPage.AreFillFormFieldsDisplayed(), "Fields to add computer are not visible");
        }

        [Then(@"Error Message is displayed next to Create this Computer field")]
        public void ThenErrorMessageIsDisplayedNextToCreateThisComputerField()
        {
            TestObjects.addNewPage.CheckErrorForComputerNameBeingUnfilled();
        }

        [Then(@"Error Message ""(.*)"" is displayed next to Introduced field")]
        public void ThenErrorMessageIsDisplayedNextToIntroducedField(string message)
        {
            TestObjects.addNewPage.CheckErrorForInvalidIntroducedDate(message);
        }

        [Then(@"Error Message ""(.*)"" is displayed next to Discontinued field")]
        public void ThenErrorMessageIsDisplayedNextToDiscontinuedField(string message)
        {
            TestObjects.addNewPage.CheckErrorForInvalidDiscontinuedDate(message);
        }

        #endregion Then





    }
}
