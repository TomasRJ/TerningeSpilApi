Feature: Regler

A short summary of the feature

@tag1
Scenario: Check if points given to the player are eqaul to the value of 3 similar dice multipled by 2
	Given list of dice with value 1,1,1,1,3,3
	When the value of 3 dice are equal
	Then the points earned should be 2000
