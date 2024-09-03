Feature: S07_Reminder

Background: 
Given I am on the login form 
Given I enter username korisnik3 and password 123123
Given I click on the Login button
Given I click ok
Given I should be redirected to Home page
Given I click events button
Given I am at events managment user form
Given I click on event in dataGrid
Given I click buy ticket button
Given I click 1 vip ticket
Given I fill email with tmodricdr20test@gmail.com
Given I click Add button
Given I should see message box Transaction is complete
Given I click ok
Given I click ok

@tag1
Scenario: S07-C02 / S07-C03 Check for not filled email messagebox after buying a ticket
Zakomentiran zadni dio podsjetnika jer Appium ne moze detektirati reminder makar se vidi

Given I click ok
Then I should get toast reminder - OVJDE TEST PADA JER NE VIDI REMINDER

@tag2
Scenario: S07-C01 Check for Toast reminder after buying a ticket with email
Zakomentiran zadni dio podsjetnika jer Appium ne moze detektirati reminder makar se vidi

Then I should get toast reminder - OVJDE TEST PADA JER NE VIDI REMINDER
