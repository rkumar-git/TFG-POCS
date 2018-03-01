/*
	Feature: Edit Submitted Assessment
*/
Feature: EditSubmittedAssessment
	As a User, 	I should able to Edit a Assessment
	from View History

@RegressionTest
Scenario: EditSubmittedAssessment_From_ViewHistory
	Given MaturityAssessment View History tab is Active
		And Listed all the Submitted Maturity Level Assessment
	When User select an Assessment from listed History
		And Click the Edit option of the Selected Assessment
	Then Selected Assessment details should be displayed to Edit.
