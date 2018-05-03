Feature: CallingBingoNumbers
	As a VP of Gaming
	I want my game to call out Bingo numbers
	So that people can play with their cards

@mytag
Scenario: Call a number in Range
	Given I have a Bingo caller
	| LowestBound | HighestBound | length |
	| 1           | 75           | 75     |
	When I call a number
	Then the number is the following range inclusive:
	| LowestBound | HighestBound | length |
	| 1           | 75           | 75     |

Scenario: Call all numbers once
	Given I have a Bingo caller
	| LowestBound | HighestBound | length |
	| 1           | 75           | 75     |
	When I call all numbers
	Then all numbers between are present
	| LowestBound | HighestBound | length |
	| 1           | 75           | 75     |
	And no number has been called more than once
