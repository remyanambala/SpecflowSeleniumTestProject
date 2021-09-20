Feature: JavaScriptAlerts
	Scenarios for testing java script alerts

Background: Pre-Condition
Given user is at the Javascript Alert Home Page


@TC_JA_JS_Alert
Scenario: Test Javscript alert
	When user click on Click for JS Alert button
	Then a javscript alert pop up is displayed
	When user click OK on the alert pop up
	Then alert pop up is closed
	And Message "<Message>" is displayed under Results

	Examples: 

	| Test | Message                           |
	| 1    | You successfully clicked an alert |