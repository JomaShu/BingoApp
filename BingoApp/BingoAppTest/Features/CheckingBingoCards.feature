Feature: CheckingBingoCards
	As a VP of Gaming
	I want my game to check player's cards when they call Bingo
	So that a winner can be decided

@mytag
Scenario: Player Call Bingo and is True
	Given a player calls Bingo after all numbers on their card have been called
	When I check the card
	Then the player is the winner

Scenario: Player Call Bingo and is False
	Given a player calls Bingo before all numbers on their card have been called
	When I check the card
	Then the player is not the winner
