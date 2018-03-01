/*
	Feature: Logout from Rapid Action Portal.
*/
Feature: LogoutFromRapidActionPortal
	As a User,
	I should be able to logout from
	Rapid Application Portal.

@SmokeTest
Scenario: LogoutFromRapidApplicationPortal
	Given RapidApplicationLaunched	
	And Logged in with valid credential
	When I click the Logout button
	Then RapidApplication should logout
