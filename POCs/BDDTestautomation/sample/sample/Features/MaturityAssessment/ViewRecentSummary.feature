/*
	Feature: View Recent summary feature.
*/
Feature: ViewRecentSummary
	As a User, I should be able to navigate to View History tab
	And view the Recent summary

@SmokeTest 
Scenario: ViewRecentSummary
	Given MaturityAssessment View History tab is Active
	When I Click RecentSummary Button
	Then Recent Maturity Level Summary should be displayed 
