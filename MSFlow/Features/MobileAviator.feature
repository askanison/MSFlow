Feature: MobileAviator


@Mobile
Scenario: Check Mobile Aviator game as a logged in user
	Given Open mobile Adjarabet page
	And Login on home page using 'sqatmaviator' and 'Paroli1#'
	And Navigate to mobile Aviator page
	When I click Play Aviator button
	Then Game is launched
	And Url is correct

@Mobile
Scenario: Check two
	Given Open mobile Adjarabet page
	And Login on home page
	And Navigate to mobile Aviator page
	When I click Play Aviator button
	Then Game is launched
	And Url is correct