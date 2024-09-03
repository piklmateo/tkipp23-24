Feature: Profile

Background:
@tag1
Scenario: Update user profile S08-C01
	Given I am on the login form 
	Given I enter username korisnik3 and password 123123 
	Given I click on the Login button
	Given I click ok
	Given I should be redirected to Home page
	Given I click profile
	Given I should be redirected to profile page
	Given I enter username <name> and surname <surname>
	When I click on Save button
	Then I should get Message User info is updated!
Examples:
| name       | surname           |
| korisnik   | korisnik30        |
| korisnikk  | korisnik31        |
| korisnikkk | korisnik32        |

@tag2
Scenario: Detail view of all user events
	Given I am on the login form 
	Given I enter username korisnik2 and password 123123 
	Given I click on the Login button
	Given I click ok
	Given I should be redirected to Home moderator page
	Given I click profile
	Given I should be redirected to profile page
	Given I click events button
	When I click on row of first event
	When I click on Show details of event
	Then I should see details of event

@tag3
Scenario: Users calendar view S08-C03
	Given I am on the login form 
	Given I enter username korisnik2 and password 123123 
	Given I click on the Login button
	Given I click ok
	Given I should be redirected to Home moderator page
	Given I click profile
	Given I should be redirected to profile page
	When I click on calendar button
	When I traverse the calendar to a specific date
	Then I should see events for that date

@tag4
Scenario: Show user transactions S08-C04
	Given I am on the login form 
	Given I enter username korisnik2 and password 123123 
	Given I click on the Login button
	Given I click ok
	Given I should be redirected to Home moderator page
	Given I click profile
	Given I should be redirected to profile page
	When I click on transactions button
	Then I should see all transactions of user

