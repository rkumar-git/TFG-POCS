/*
	Feature: Navigate to Maturity Assessment Page.
*/
Feature: NavigateToMAPage
	As a User, I should be able to access Maturity Assess Page,
	by clicking the Maturity Assess link
		
	@SmokeTest
	Scenario: NavigateToMaturityAssessmentPageTest	
		Given RapidApplicationLaunched	
		And Logged in with valid credential
		When User Clicks on Maturity Assess Link from Navigation Panel
		Then Maturity Assess page should be displayed
			And New Assessment tab should be displayed in the MaturityAssessment Page
			And View History Details tab should be displayed in the Maturity Assessment Page
