/*
	Feature: Select and Submit desired Maturity Level
*/
Feature: SelectAndSubmit_DesiredMaturityLevel
	User should be able to Select Maturity Level 
	Desired State Levels and Click Next Button

@RegressionTest
Scenario: SelectAndSubmitDesiredMaturityLevelTest
	Given The MaturityAssessment Page New Assessment Tab is Active
	When User Select all values from  Desired Functional State area from dropdown
		And Click Next Button
	Then  Current State Maturity level questions should be displayed