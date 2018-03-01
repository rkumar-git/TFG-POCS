/*
	Feature: Answer Desired Capabilities and Submit.
*/
Feature: AnswerDesiredStateLevel_And_Submit
	Provide Answer to "Current State Maturity Level" 
	Submit Selected Answers

@RegressionTest
Scenario: AnswerDesiredStateLevel_And_Submit
	Given "Current State Maturity Level" Questions page is Active
	When User Select Answers of each question
		And Click Submit Button
	Then the Desired state selection page should be displayed 
		And the message "Assessment Submitted Successfully!" should be displayed.
