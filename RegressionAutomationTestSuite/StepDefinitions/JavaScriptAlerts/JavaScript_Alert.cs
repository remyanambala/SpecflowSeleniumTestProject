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
    public sealed class JavaScript_Alert
    {
       

        #region When
        [When(@"user click on Click for JS Alert button")]
        public void WhenUserClickOnClickForJSAlertButton()
        {
            TestObjects.jsAlertPage.ClickOnJSAlert();
        }
       
        #endregion When

        #region Then
        [Then(@"a javscript alert pop up is displayed")]
        public void ThenAJavscriptAlertPopUpIsDisplayed()
        {
            TestObjects.jsAlertPage.CheckJsAlert();
        }

    
        #endregion Then


    }
}
