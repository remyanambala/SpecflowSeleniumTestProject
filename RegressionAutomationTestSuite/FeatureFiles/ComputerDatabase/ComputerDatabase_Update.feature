Feature: Update an existing computer under computer database 
	Scenarios for updating existing computer records under computer database

Background: Pre-Condition
Given user is at the Computer database Home Page
And Add a new Computer button should be visible 

@TC_CD_update_computer_record
Scenario Outline: Update an existing computer
When user enters text "<Search Text>" in filter by computer name text box
And click on Filter by name button
Then Computer record corresponding to Search Text is listed in computer grid list
When user click on the searched computer record row in the computer grid list
Then Edit a computer page is displayed 
When user updates values for fields "<Computer name>", "<Introduced>", "<Discontinued>" , "<Company>" 
And click on Save this computer button
Then Home page is displayed
And Message "<Message>" is displayed

#Enter NA if value needn't be entered for a field
Examples:
| Test     | Search Text       | Computer name              | Introduced | Discontinued           | Company  | Message                                            |
| 1        | ASCI Blue Pacific | NA                         | NA         |        2020-08-15      | NA       | Done ! Computer ASCI Blue Pacific has been updated |
| 2        | ASCI Blue Pacific | New                        | 1996-01-01 |        NA              | Nokia    | Done ! Computer New has been updated               |
| 3        | ASCI Blue Pacific | NA                         |   NA       |        2020-09-15      | Nokia    | Done ! Computer ASCI Blue Pacific has been updated |