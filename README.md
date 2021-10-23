# **SpecFlow Selenium Test Project**

This Repository contains manual test cases and automated test scripts for testing below web applications:

*	http://computer-database.gatling.io/computers                                 
*	https://the-internet.herokuapp.com/javascript_alerts 

Manual test case document: Test Case_Suite.xlsx

Automation Test Suite can be found under folder 'RegressionAutomationTestSuite'.
Automation framework is implemented using Specflow + MSTest framework (C#) and Selenium Webdriver.

### **Project Structure**

#### Configuration
   app.config: Browser and URLs are specified under this file
   
#### Folders
- FeatureFiles: Contains all the SpecFlow feature files
- StepDefinitions: Contains step definitions correspondiong to the SpecFlow feature file
- SpecFlowHooks: Contain SpecFlow hook file to instantiate webdriver before each scenario and quit the driver after each scenario
- PageObjects: Page Object Model (POM) pattern is used for framework implementation. It contains a POM class for each test web page
- Resources: Contains class files to read the app config file and to instantiate/ quit webdriver. It has a TestObjects static class which hold the webdriver and page objects so that it can be shared between the step definitions.

### **Steps to run the automation test suite**
- Download the code repository and unzip it
- Open Visual Studio App and add extension - 'SpecFlow for Visual Studio 2019'
- Restart Visual Studio App once extension is installed
- Open solution 'RegressionTestSuite.sln' from under 'RegressionAutomationTestSuite' folder in Visual Studio App
- Rebuild solution
- Open Test->TestExplorer 
- SpecFlow tests are listed
- Run the tests




