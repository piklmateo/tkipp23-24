Feature: LocationSearch

Background: 
	Given I am on the login form 
	Given I enter username korisnik3 and password 123123 
	Given I click on the Login button
	Given I click ok
	Given I should be redirected to Home page
	Given I click events button
	Given I should be redirected to Events page

@tag1
Scenario: Search by users current location S10-C01
	When I click on button Filter By Location
	Then I should click yes on the message If I want to use my current location
	Then I should not get message Lokacija nije uspiješno dohvaćena

@tag2
Scenario: Search by users hand picked location S10-C02
	When I click on button Filter By Location
	Then I should click on no the message If I want to use my current location

@tag3
Scenario: Location privacy settings disabled S10-C03
	When I click on button Filter By Location
	Then I should click yes on the message If I want to use my current location
	Then I should get message Lokacija nije uspiješno dohvaćena
