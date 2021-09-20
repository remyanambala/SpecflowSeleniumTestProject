Feature: Delete an existing computer under computer database 
	Scenarios for deleting existing computer records under computer database

Background: Pre-Condition
Given user is at the Computer database Home Page
And Add a new Computer button should be visible 

@TC_CD_delete_computer_record
Scenario Outline: Delete an existing computer
When user enters text "<Search Text>" in filter by computer name text box
And click on Filter by name button
Then Computer record corresponding to Search Text is listed in computer grid list
When user click on the searched computer record row in the computer grid list
Then Edit a computer page is displayed 
When user clicks on Delete this computer button 
Then Home page is displayed
And Message "<Message>" is displayed


Examples:
| Test     | Search Text       |  Message                                            |
| 1        | ASCI Blue Pacific | Done ! Computer ASCI Blue Pacific has been deleted  |
