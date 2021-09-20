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
    public sealed class JavaScript_Prompt
    {
        #region When
        [When(@"user click on Click for JS Prompt button")]
        public void WhenUserClickOnClickForJSPromptButton()
        {
            TestObjects.jsAlertPage.ClickOnJSPrompt();
        }

        [When(@"user enters text ""(.*)"" on prompt text box")]
        public void WhenUserEntersTextOnPromptTextBox(string text)
        {
            TestObjects.jsAlertPage.EnterTextOnJSPrompt(text);
        }
        #endregion When

        #region Then
        [Then(@"a javscript prompt pop up is displayed")]
        public void ThenAJavscriptPromptPopUpIsDisplayed()
        {
            TestObjects.jsAlertPage.CheckJsPrompt();
        }
        #endregion Then

    }
}
