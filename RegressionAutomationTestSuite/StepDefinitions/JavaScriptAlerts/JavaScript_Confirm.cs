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
    public sealed class JavaScript_Confirm
    {
        #region When
        [When(@"user click on Click for JS Confirm button")]
        public void WhenUserClickOnClickForJSConfirmButton()
        {
            TestObjects.jsAlertPage.ClickOnJSConfirm();
        }
        #endregion When

        #region Then

        [Then(@"a javscript confirm pop up is displayed")]
        public void ThenAJavscriptConfirmPopUpIsDisplayed()
        {
            TestObjects.jsAlertPage.CheckJsConfirm();
        }
        #endregion Then

    }
}
