Feature: JavaScript Confirm
	Scenarios for testing java script Confirm alerts

Background: Pre-Condition
Given user is at the Javascript Alert Home Page
When user click on Click for JS Confirm button
Then a javscript confirm pop up is displayed


@TC_JA_JS_Confirm_OK
Scenario Outline: Test clicking OK on Javscript confirm alert
	When user click OK on the alert pop up
	Then alert pop up is closed
	And Message "<Message>" is displayed under Results

	Examples: 

	| Test | Message                           |
	| 1    | You clicked: Ok                   |


@TC_JA_JS_Confirm_Cancel
Scenario Outline: Test clicking Cancel on Javscript confirm alert
	When user click Cancel on the alert pop up
	Then alert pop up is closed
	And Message "<Message>" is displayed under Results

	Examples: 

	| Test | Message                               |
	| 1    | You clicked: Cancel                   |