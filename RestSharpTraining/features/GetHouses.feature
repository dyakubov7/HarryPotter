Feature: GetHouses
	

@get @gethouses @regression @smoke
Scenario: get houses
	Given I have my testing endpoint "/sortingHat"
	And send the get request
	Then my status code should be "OK"
	Then Assert that it assigns a proper house

