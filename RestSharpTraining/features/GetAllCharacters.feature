Feature: GetAllCharacters
	

@get @getallcharacters @smoke @regression
Scenario: Get All Characters

	Given I have my testing endpoint "/characters"
	When add my api key
	When send the get request
	Then my status code should be "OK"
	Then Assert that the number of characters is "195"

	@multipleRequests @regression
	Scenario: Multiple Request test

	Given I have my assigned house
	Given I have my testing endpoint "/characters"
	When add my api key
	When send the get request
	Then my status code should be "OK"
	Then Assert that the number of characters is "195"

