/*
	Feature: View All Submitted History.
*/
Feature: ViewAll_SubmittedAssessmentHistory
	As a User, I should be able to navigate to View History tab
	And view the all Submitted History.

@SmokeTest
Scenario: ViewAll_SubmittedAssessment
	Given MaturityAssessment View History tab is Active
	When I Click ViewAll Button
	Then Submitted Assessment should be listed
