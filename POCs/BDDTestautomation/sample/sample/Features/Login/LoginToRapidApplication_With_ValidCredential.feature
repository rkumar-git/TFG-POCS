/*
	Feature: Login to Rapid Application with Valid Credentials.
*/
Feature: LoginToRapidApplication_With_ValidCredential
	As a User I should be able login to Rapid Application
	with valid credentials.

@SmokeTest
Scenario: LoginToRapidApplication_ValidCredentials
	Given RapidApplicationLaunched	
	When User Enter valid Username and Password
	And Click Login Button
	Then RapidApplication Home should be displayed