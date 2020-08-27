Feature: GetAllCharacters
	

@get @getallcharacters @smoke @regression
Scenario: Get All Characters
	Given I have my testing endpoint "/characters"
	And add my api key
	And send the get request
	Then my status code should be "OK"
	Then Assert that the number of characters is "195"