Feature: Textbox

Validate TextBox field Entry

@ValidTextboxEntry
Scenario: Textbox contains valid input
	Given page element is a textbox
	And data provided is valid
	When text is entered
	Then value is accepted and goes to the next form field
