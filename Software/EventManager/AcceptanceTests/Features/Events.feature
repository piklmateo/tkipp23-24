Feature: Events

As a user
I want to be able to add new, 
and delete existing events

Background: 
    Given I launch the application
    Given I should see the login form
    Given I ensure that the login form is displayed

@tag1
Scenario: S03-C01 - Add event
	Given I enter username korisnik2 and password 123123
	Given I click the Login button
	Given I click button ok
	Given I should be redirected to Home moderator page
	Given I click event
	Given I am redirected to event page
	Given I click add event button
	Given I am redirected to add event page
	Given i enter event name test188
	Given I click button add
	Given I should remain on add event page
	Given I click button ok
	Then I am redirected to event page


@tag2
Scenario: S03-C02 - Empty event name
	Given I enter username korisnik2 and password 123123
	Given I click the Login button
	Given I click button ok
	Given I should be redirected to Home moderator page
	Given I click event
	Given I am redirected to event page
	Given I click add event button
	Given I am redirected to add event page
	Given i leave event name field blank
	Given I click button add
	Then I should remain on add event page
	Then I should see MessageBox with message Neispravan naziv eventa.


@tag3
Scenario: S03-C03 - Past date
	Given I enter username korisnik2 and password 123123
	Given I click the Login button
	Given I click button ok
	Given I should be redirected to Home moderator page
	Given I click event
	Given I am redirected to event page
	Given I click add event button
	Given I am redirected to add event page
	Given i enter event name test188
	Then I enter past date

@tag1
Scenario: S03-C04 - Delete event
	Given I enter username korisnik2 and password 123123
	Given I click the Login button
	Given I click button ok
	Given I should be redirected to Home moderator page
	Given I click event
	Given I am redirected to event page
	Given I select event with name test188 from the datagridview
	Given I click button delete
	Then I should see MessageBox with message Uspješno brisanje eventa: test188
	