Feature: S05_QrCode

User can check QrCode for tickets of events that he signed up/paid for. Moderator
can check which users signed up/paid for which event.
Background: 
Given I am on the login form 

@tag1
Scenario: S05-C04 / S05-C02 QrCode with no tickets
Given I enter username korisnik3 and password 123123 
Given I click on the Login button
Given I click ok
Given I should be redirected to Home page
Given I click profile
Given I should be redirected to profile page
Given I click on my events button
Given I should see the My events page
Given I click Show details of event button
Then I should see the error Didn't select the event!

@tag2
Scenario: S05-C03 Moderator checks users QrCode
Given I enter username korisnik2 and password 123123 
Given I click on the Login button
Given I click ok
Given I should be redirected to Home moderator page
Given I click events button
Given I am at events managment form
When I click check tickets
Then I should see form with users that bought tickets for that event

@tag3
Scenario: S05-C01 QrCode with bought tickets for some events
Given I enter username korisnik2 and password 123123 
Given I click on the Login button
Given I click ok
Given I should be redirected to Home moderator page
Given I click profile
Given I should be redirected to profile page
Given I click on my events button
Given I should see the My events page
Given I click item on dataGrid
Given I click Show details of event button
When I should be redirected to FrmEvent page
Then I should see QrCode with picture