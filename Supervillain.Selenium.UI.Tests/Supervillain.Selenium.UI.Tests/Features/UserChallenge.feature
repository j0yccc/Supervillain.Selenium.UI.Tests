Feature: User Challenge

Background: Create user and start the challenge
	Given user is created

Scenario: User challenge correct answer final score
	When the user start the challenge 'Take the bus'
	And the user choose the correct answer
	Then the score '100' is displayed
	When the user check the final score
	Then the final score '100' is displayed

Scenario: User challenge correct answer next challenge
	When the user start the challenge 'Take the bus'
	And the user choose the correct answer
	Then the next challenge is displayed

Scenario: User challenge incorrect answer
	When the user start the challenge 'Take the bus'
	And the user choose the incorrect answer
	Then the try again option is displayed

Scenario: User challenge timeout
	When the user start the challenge 'Go to a public place'
	And the challenge timeout
	Then the covid poster is displayed