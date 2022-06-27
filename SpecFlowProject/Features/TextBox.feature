Feature: TextBox
	Simple calculator for adding two numbers

@mytag
Scenario: Submit Text Box form
	Given I navigate to 'Text Box' page
	When I fill the form in with 'valid' information
 	And I click 'Submit' button
	Then I see 'valid' Text Box form output