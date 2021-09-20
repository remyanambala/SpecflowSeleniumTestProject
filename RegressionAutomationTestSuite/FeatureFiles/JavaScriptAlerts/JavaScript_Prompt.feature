Feature: JavaScript Prompt
	Scenarios for testing java script Prompt alerts

Background: Pre-Condition
Given user is at the Javascript Alert Home Page
When user click on Click for JS Prompt button
Then a javscript prompt pop up is displayed


@TC_JA_JS_Prompt_OK
Scenario Outline: Test clicking OK on Javscript prompt alert
	When user enters text "<Text>" on prompt text box
	And user click OK on the alert pop up
	Then alert pop up is closed
	And Message "<Message>" is displayed under Results

	Examples: 

	| Test | Text   | Message                          |
	| 1    | Hi     |You entered: Hi                   |


@TC_JA_JS_Prompt_Cancel
Scenario Outline: Test clicking Cancel on Javscript prompt alert
	When user click Cancel on the alert pop up
	Then alert pop up is closed
	And Message "<Message>" is displayed under Results

	Examples: 

	| Test | Message                               |
	| 1    | You entered: null                     |