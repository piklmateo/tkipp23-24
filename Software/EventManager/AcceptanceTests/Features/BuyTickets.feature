Feature: BuyTickets
Background: 
	Given I am on the login form 
	Given I enter username korisnik3 and password 123123 
	Given I click on the Login button
	Given I click ok
	Given I should be redirected to Home page
	Given I click events button
	Given I should be redirected to Events page

@tag1
Scenario: Buy Tickets as a registered user S09-C01
	When I click on the first event in the data grid
	When I click on the Buy Tickets button
	Then I should be redirected to the Buy Tickets page
	When I input data for the tickets
	When I click on the Add button
	Then I should see a message that the Transaction is complete

@tag2
Scenario: Detail view of an event S09-C02
	When I click on the first event in the data grid
	When I click on the Details button
	Then I should be redirected to the Details page

	
@tag3
Scenario: Filter by category for events S09-C03
	When I click on dropdown for category and select Festival
	When I clik on the Filter button
	Then I should see the data grid fill with data with the Category Festival in it