Feature: Test sorting hat
	

@getSortingHat
Scenario: get sorting hat
	Given I set up all the variables
	And send my get request
	Then status code should be "OK"
	Then Assert that you are assigned to one of the houses

