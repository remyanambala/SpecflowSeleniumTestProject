Feature: View a computer under computer database 
	Scenarios for viewing existing computer records under computer database

Background: Pre-Condition
Given user is at the Computer database Home Page
And Add a new Computer button should be visible 

@TC_CD_view_computer_record
Scenario Outline: View an existing computer
When user enters text "<Search Text>" in filter by computer name text box
And click on Filter by name button
Then Computer record corresponding to Search Text is listed in computer grid list
When user click on the searched computer record row in the computer grid list
Then Edit a computer page is displayed 
And correct values for fields "<Computer name>", "<Introduced>", "<Discontinued>" , "<Company>" are displayed
When user click on Cancel button
Then Home page is displayed

Examples:
| Test     | Search Text              | Computer name    | Introduced  | Discontinued  | Company | 
| 1        |ASCI Blue Pacific         |ASCI Blue Pacific | 1998-01-01  |               |IBM      | 


@TC_CD_view_computer_record
Scenario Outline: To verify that message 'Nothing to display' is displayed when a computer record is not found
When user enters text "<Search Text>" in filter by computer name text box
And click on Filter by name button
Then text Nothing to display is seen and no computer records are seen

Examples:
| Test     | Search Text              |  
| 1        |testComputer              |
