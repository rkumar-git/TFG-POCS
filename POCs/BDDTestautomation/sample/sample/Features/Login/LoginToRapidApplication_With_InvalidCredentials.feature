/*
	Feature name: Login to Rapid application with invalid credentials.
*/
Feature: LoginToRapidApplication_With_InvalidCredentials
	As a User,
	If I enter invalid user name and password
	I should be alerted with valid alert message.

@SmokeTest
Scenario: LoginToRapidApplication_With_InvalidCredentials
	Given RapidApplicationLaunched	
	When User Enter Invalid Username and Password
	And Click Login Button
	Then Alert Message should be displayed