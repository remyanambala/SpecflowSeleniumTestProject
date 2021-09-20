using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegressionTestSuite.PageObjects;
using RegressionTestSuite.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RegressionTestSuite.StepDefinitions.JavaScriptAlerts
{
    [Binding]
    public sealed class JavaScript_CommonSteps
    {
        #region Given
        [Given(@"user is at the Javascript Alert Home Page")]
        public void GivenUserIsAtTheJavascriptAlertHomePage()
        {
            TestObjects.jsAlertPage = new JavaScriptHomePage(TestObjects.Driver);
            TestObjects.jsAlertPage.GoTo();
            Assert.IsTrue(TestObjects.jsAlertPage.IsPageLoaded, "Java script alert page is not loaded");
        }
        #endregion Given

        #region When

        [When(@"user click OK on the alert pop up")]
        public void WhenUserClickOKOnTheAlertPopUp()
        {
            TestObjects.jsAlertPage.ClickOKOnJSAlertPopUps();
        }

        [When(@"user click Cancel on the alert pop up")]
        public void WhenUserClickCancelOnTheAlertPopUp()
        {
            TestObjects.jsAlertPage.ClickCancelOnJSAlertPopUps();
        }
        #endregion When

        #region Then

        [Then(@"alert pop up is closed")]
        public void ThenAlertPopUpIsClosed()
        {
            TestObjects.jsAlertPage.CheckJsAlertPopUpsIsClosed();
        }


        [Then(@"Message ""(.*)"" is displayed under Results")]
        public void ThenMessageIsDisplayedUnderResults(string message)
        {
            TestObjects.jsAlertPage.CheckMessage(message);
        }
        #endregion Then

    }
}
