using RegressionTestSuite.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RegressionTestSuite.SpecFlowHooks
{
    [Binding]
    public sealed class SpecFlowHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
       
        [BeforeScenario]
        public void BeforeScenario()
        {
            //Reads Appconfig and gets the settings
            //Instantiates the webdriver before each scenario
            DriverCreator.InitWebdriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //Closes all browser windows and terminates webdriver session
            DriverCreator.TearDown();

        }

    }
}
