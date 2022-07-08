Feature: PracticeForm

@smoke
Scenario: Fill in Student Registration Form
	Given I navigate to 'Practice Form' page
	When I fill Practice form in with 'main' information
	And I click 'Submit' button
	Then I see 'main' Practice form output