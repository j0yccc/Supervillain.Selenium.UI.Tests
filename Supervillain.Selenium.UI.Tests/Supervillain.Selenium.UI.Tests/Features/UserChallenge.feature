Feature: User Challenge

Background: Create user and start the challenge
	Given user is created

Scenario: User challenge Correct
	When the user start the challenge 'Take the bus'
	And the user choose the correct answer
	Then the score is displayed

Scenario: User challenge Incorrect
	When the user start the challenge 'Take the bus'
	And the user choose the incorrect answer
	Then the next challenge is displayed

Scenario: User challenge Timeout
	When the user start the challenge 'Go to a public place'
	And the challenge timeout
	Then the try again option is displayed