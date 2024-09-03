Feature: Tickets

As a user
I want to update existing tickets with new information

Background: 
    Given I launch the application
    Given I should see the login form
    Given I ensure that the login form is displayed

@tag1
Scenario: S04-C01 - Empty event field
	Given I enter username korisnik2 and password 123123
	Given I click the Login button
	Given I click button ok
	Given I should be redirected to Home moderator page
	Given I click ticket
	Given I am redirected to ticket page
	Given I click update button
	Given I am redirected to edit ticket page
	Given I leave event empty and enter price 24 amount 2
	Given I click update button
	Given I should remain on edit ticket page
	Then I should see MessageBox with message Event nije odabran ili je neispravan.

@tag2
Scenario: S04-C02 - Invalid price
	Given I enter username korisnik2 and password 123123
	Given I click the Login button
	Given I click button ok
	Given I should be redirected to Home moderator page
	Given I click ticket
	Given I am redirected to ticket page
	Given I click update button
	Given I am redirected to edit ticket page
	Given I enter price 33a and amount 20
	Given I click update button
	Given I should remain on edit ticket page
	Then I should see MessageBox with message Neispravan format cijene. Dozvoljene su samo brojke s maksimalno 4 decimalna mjesta.


@tag3
Scenario: S04-C03 - Invalid amount
	Given I enter username korisnik2 and password 123123
	Given I click the Login button
	Given I click button ok
	Given I should be redirected to Home moderator page
	Given I click ticket
	Given I am redirected to ticket page
	Given I click update button
	Given I am redirected to edit ticket page
	Given I enter price 16 and amount -2
	Given I click update button
	Given I should remain on edit ticket page
	Then I should see MessageBox with message Neispravan format količine. Dozvoljene su samo cijele brojke.