Feature: GeneratingBingoCards
	As a VP of Gaming
	I want my game to generate random Bingo cards
	So that people can play

@mytag
Scenario: Generate Bingo Card
	Given I have a Bingo card generator
	When I generate a Bingo card with 5 spaces per row
	| LowerBound | UpperBound |
	| 1          | 15         |
	| 16         | 30         |
	| 31         | 45         |
	| 46         | 60         |
	| 61         | 75         |
	Then the generated card has 25 unique spaces
	And column $column only contains numbers between $lowerBound and $upperBound inclusive
	| LowerBound | UpperBound |
	| 1          | 15         |
	| 16         | 30         |
	| 31         | 45         |
	| 46         | 60         |
	| 61         | 75         |
	And the generated card has a FREE space in the middle
 

