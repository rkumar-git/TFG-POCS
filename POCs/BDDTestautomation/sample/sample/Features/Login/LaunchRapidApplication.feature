Feature: LaunchRapidApplication
	As User, I shoud be able launch the 
	DevOps Portal "Rapid Application".

@SmokeTest
Scenario: LaunchRapidApplication
	Given Browser Opened and Active
	When I enter the Rapid Application url 
	Then DevOps Portal should be launched
		And UserName EditBox should be displayed and enabled
		And Password EditBox should be displayed and enabled
		And Login Button shhould be displayed and enabled
		And Forget Password Link should be displayed and enabled