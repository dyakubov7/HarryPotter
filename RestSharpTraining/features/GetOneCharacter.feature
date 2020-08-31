Feature: Get A Character

@get @getacharacter @regression @smoke
Scenario Outline: get one character
	Given I have my testing endpoint "/characters/" and <id> of the character
	When add my api key
	When send the get request
	Then my status code should be "OK"
	Then Assert that name is <name>

	Examples:
		| id                       | name               |
		| 5a0fa4daae5bc100213c232e | Hannah Abbott      |
		| 5a107f17e0686c0021283b1d | Alecto Carrow      |
		| 5a0fa54aae5bc100213c232f | Bathsheda Babbling |



		