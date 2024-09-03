Feature: Registration
  As a user
  I want to register with a unique username
  So that I can access the system

  Background: 
    Given I launch the application
    Given I should see the login form
    Given I ensure that the login form is displayed

  @tag1
  Scenario: S02-C01 - Entering an existing username
    Given I click on label Don't have an account? Sign up
    Given I should be redirected to registration page
    Given I enter name testAT surname testAT address testAT12 phone 0955352447 username korisnik2 password 123123
    When I click button sign up
    Then I should remain on register page
    Then I should see MessageBox with message Korisničko ime već postoji


@tag2
Scenario: S02-C02 - Missing information
    Given I click on label Don't have an account? Sign up
    Given I should be redirected to registration page
    Given I enter surname testAT address testAT12 phone 0955352447 username korisnik2 password 123123 without entering the name
    When I click button sign up
    Then I should remain on register page
    Then I should see MessageBox with message Molimo Vas da ispunite sva potrebna polja

@tag3
  Scenario: S02-C03 - Succesfull registration
    Given I click on label Don't have an account? Sign up
    Given I should be redirected to registration page
    Given I enter name testAT surname testAT address testAT12 phone 0955352447 username testAT516 password 123123
    When I click button sign up
    And I should see MessageBox with message Uspješna registracija
    And I press ok button
    Then I should be redirected to login form