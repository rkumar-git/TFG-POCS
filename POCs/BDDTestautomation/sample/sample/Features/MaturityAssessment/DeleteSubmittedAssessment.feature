/*
	Feature: Delete Submitted Assessment.
*/

Feature: DeleteSubmittedAssessment
		As a User, 
	I should be able to delete a 
	Recored from View History

@RegressionTest
Scenario: DeleteSubmittedAssessment_No_From_ViewHistoryTab
	Given MaturityAssessment View History tab is Active
		And Listed all the Submitted Maturity Level Assessment
	When User select an Assessment from listed History
		And Click the Delete Button of the Selected Assessment
	Then Selected Assessment details should be deleted 
		And Should not listed in the View History details.