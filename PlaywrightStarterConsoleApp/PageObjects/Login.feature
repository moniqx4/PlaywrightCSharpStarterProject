Feature: Login
	Simple login page

@loginToSupervisorDashboard
Scenario: User can log in with valid credentials
	Given the user is on LoginPage
	And user types in companyAlias in companyAlias field
	And user types in username in username field
	And user types in password in password field
	When the login button is clicked the challenge page appears
	Then the user clicks on the skip button and goes to 