/*
	Feature: Verify Maturity Assessment desired state fields.
*/
Feature: VarifyMaturityAssessment_DesiredStateFields
	As a User, I should be able to View, 
	Select and Submit the Desired State values

@SmokeTest
Scenario: VerifyDesiredStateFieldListedTest
	Given RapidApplicationLaunched	and LoggedIn with valid credential
	When User Click MaturityAssessment Link	
	Then Maturity Assessment Page is Active
		And Desired State Button should be displayed
		And Current State Button Should be displayed
		And Organization and Process dropdown should be displayed and enabled
		And Continuous Integration dropdown should be displayed and enabled
		And Continuous Inspection dropdown should be displayed and enabled
		And Continuous Feedback dropdown should be displayed and enabled
		And Continuous Delivery Deployment dropdown should be displayed and enabled
		And Continuous Testing dropdown should be displayed and enabled
		And Continuous Infrastructure dropdown should be displayed and enabled
		And Continuous Monitoring dropdown should be displayed and enabled

