Feature: S06_Facebook

Background: 
Given I am on the login form 

@tag1
Scenario: S06-C01 Moderators should have the option to share events
Given I enter username korisnik2 and password 123123 
Given I click on the Login button
Given I click ok
Given I should be redirected to Home moderator page
Given I click events button
Given I am at events managment form
Given I click on event in dataGrid
Given I click details button
When I should see form with details of event
Then I should see button to share to Facebook

@tag2
Scenario: S06-C02 Users should not have the option to share events
Given I enter username korisnik3 and password 123123
Given I click on the Login button
Given I click ok
Given I should be redirected to Home page
Given I click events button
Given I am at events managment user form
Given I click on event in dataGrid
Given I click user details button
When I should see users form with details of event
Then I should not see button to share to Facebook
