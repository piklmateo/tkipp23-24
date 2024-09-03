Feature: Login

As a user
I want to login with a unique username and password
So that I can access the system

Background: 
    Given I launch the application
    Given I should see the login form
    Given I ensure that the login form is displayed

@tag1
Scenario: S01-C01 - Invalid Credentials
    When I enter the username kriviKorisnik and the password kriviPassword
    When I click the Login button
    Then I expect to remain on the login form
    Then I should see MessageBox with message Pogrešno korisničko ime ili lozinka

@tag2
Scenario: S01-C02 - Invalid username
    When I enter the username korisni2 and the password 123123
    When I click the Login button
    Then I expect to remain on the login form
    Then I should see MessageBox with message Pogrešno korisničko ime ili lozinka

@tag3
Scenario: S01-C03 - Invalid password
    When I enter the username korisnik2 and the password 1231234
    When I click the Login button
    Then I expect to remain on the login form
    Then I should see MessageBox with message Pogrešno korisničko ime ili lozinka

@tag4
Scenario: S01-C04 - Empty username field
    When I enter the password 123123 without the username
    When I click the Login button
    Then I expect to remain on the login form
    Then I should see MessageBox with message Molimo Vas da unesete korisničko ime.

@tag5
Scenario: S01-C05 - Empty password field
    When I enter the username korisnik2 without the password
    When I click the Login button
    Then I expect to remain on the login form
    Then I should see MessageBox with message Molimo Vas da unesete lozinku.

