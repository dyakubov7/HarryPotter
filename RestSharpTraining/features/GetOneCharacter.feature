Feature: Get A Character

@get @getacharacter @regression @smoke
Scenario Outline: get one character
	Given I have my testing endpoint "/characters/" and <id> of the character
	When add my api key
	When send the get request
	Then my status code should be "OK"
	Then Assert that name is <name>
	Then Assert the json schema with <filename>

	Examples:
		| id                       | name               | filename                  |
		| 5a0fa4daae5bc100213c232e | Hannah Abbott		| 'HannahAbbotSchema'       |
		| 5a107f17e0686c0021283b1d | Alecto Carrow      | 'AlectoCarrowSchema'      |
		| 5a0fa54aae5bc100213c232f | Bathsheda Babbling | 'BathshedaBabblingSchema' |