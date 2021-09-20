Feature: Create a computer under computer database 
	Scenarios for covering creation of new computers under computer database

Background: Pre-Condition
Given user is at the Computer database Home Page
And Add a new Computer button should be visible 
When user click on Add a new Computer button
Then Add a computer page is displayed
And fields Computer name, Introduced, Discontinued and Company are displayed

@TC_CD_add_computer
Scenario Outline: Create a new computer
When user enters values for "<Computer name>", "<Introduced>", "<Discontinued>" and "<Company>"
And click on Create this computer button
Then Home page is displayed
And Message "<Message>" is displayed

Examples:
| Test     | Computer name | Introduced | Discontinued | Company | Message                                        |
| 1        | Test Computer | 2000-08-25  | 2015-08-10   | Nokia   | Done ! Computer Test Computer has been created |



@TC_CD_add_computer_without_values
Scenario: To verify that error message is displayed when a computer is attempted to be added without any values
When click on Create this computer button
Then Error Message is displayed next to Create this Computer field

@TC_CD_add_computer_invalid_date_values
Scenario Outline: To verify that error message is displayed when invalid date values are added during adding a computer
When user enters values for "<Computer name>", "<Introduced>", "<Discontinued>" and "<Company>"
And click on Create this computer button
Then Error Message "<Message1>" is displayed next to Introduced field
And Error Message "<Message2>" is displayed next to Discontinued field

Examples:
| Test | Computer name | Introduced | Discontinued | Company | Message1                                                                                                  | Message2                                                                                                          |
| 1    | Test Computer | AA         | 10-08-2015   | Nokia   | Failed to decode date : java.time.format.DateTimeParseException: Text 'AA' could not be parsed at index 0 | Failed to decode date : java.time.format.DateTimeParseException: Text '10-08-2015' could not be parsed at index 0 |
