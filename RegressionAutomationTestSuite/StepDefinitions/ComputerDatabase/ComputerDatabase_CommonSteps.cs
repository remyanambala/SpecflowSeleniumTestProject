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
    public sealed class ComputerDatabase_CommonSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public ComputerDatabase_CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        #region Given
        [Given(@"user is at the Computer database Home Page")]
        public void GivenUserIsAtTheComputerDatabaseHomePage()
        {
            TestObjects.compDBHomePage = new ComputerDBHomePage(TestObjects.Driver);
            TestObjects.compDBHomePage.GoTo();
            Assert.IsTrue(TestObjects.compDBHomePage.IsPageLoaded, "Computer database home page is not loaded");


        }

        [Given(@"Add a new Computer button should be visible")]
        public void GivenAddANewComputerButtonShouldBeVisible()
        {
            Assert.IsTrue(TestObjects.compDBHomePage.IsAddNewBtnVisible(), "Add New Button is not visible on home page");
        }
        #endregion Given

        #region When
        [When(@"user enters text ""(.*)"" in filter by computer name text box")]
        public void WhenUserEntersTextInFilterByComputerNameTextBox(string searchText)
        {
            Assert.IsTrue(TestObjects.compDBHomePage.EnterFilterText(searchText), "Search text couldn't be entered");
        }


        [When(@"click on Filter by name button")]
        public void WhenClickOnFilterByNameButton()
        {
            Assert.IsTrue(TestObjects.compDBHomePage.ClickOnFilterBtn(), "Filter button couldn't be clicked");
        }

        [When(@"user click on the searched computer record row in the computer grid list")]
        public void WhenUserClickOnTheSearchedComputerRecordRowInTheComputerGridList()
        {
            //Click on the first computer record
            TestObjects.editPage = TestObjects.compDBHomePage.ClickOnComputerRecord(1);
        }

        #endregion When

        #region Then

        [Then(@"Home page is displayed")]
        public void ThenHomePageIsDisplayed()
        {
            Assert.IsTrue(TestObjects.compDBHomePage.IsPageLoaded, "Computer database home page is not loaded");
        }

       

        [Then(@"Computer record corresponding to Search Text is listed in computer grid list")]
        public void ThenComputerRecordCorrespondingToSearchTextIsListedInComputerGridList()
        {
            Assert.IsTrue(TestObjects.compDBHomePage.IsSearchedComputerFound(), "No matching computer is listed");
        }



        [Then(@"Edit a computer page is displayed")]
        public void ThenEditAComputerPageIsDisplayed()
        {
            Assert.IsTrue(TestObjects.editPage.IsPageLoaded, "Edit computer page is not loaded");
        }

        [Then(@"Message ""(.*)"" is displayed")]
        public void ThenMessageIsDisplayed(string message)
        {
            Assert.IsTrue(TestObjects.compDBHomePage.VerifyMessageDisplayed(message), "Expected message is not displayed");
        }
        #endregion Then

    }
}
