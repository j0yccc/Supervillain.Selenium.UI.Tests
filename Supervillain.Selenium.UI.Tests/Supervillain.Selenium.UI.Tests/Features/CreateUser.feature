Feature: Create User

@mytag
Scenario: Create User
	Given the page is loaded
	When user create warrior 'Test'
	Then the user 'Test' is created
	And the game page is displayed