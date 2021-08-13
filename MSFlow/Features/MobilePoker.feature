@Mobile
Feature: MobilePoker

 
	Scenario: Check Mobile Poker as a logged in user
		Given Open mobile Adjarabet page
		And Login on home page using 'sqatmpoker' and 'Paroli1#'
		And Navigate to '<Mobile Poker>' page
		When I click '<Play New Poker>' button
		Then Mobile Poker game is launched
		And '<Url>' is correct
	Examples: 
	| Mobile Poker  | Play New Poker  | Url |
	| Mobile Poker	| Play New Poker  | https://poker.adjarabet.com/?https://launch.spribegaming.com/poker?brand=adjarabet.com&currency=GEL&game_id=poker&    |


	 Scenario: Check Mobile Poker as not authorized user
		Given Open mobile Adjarabet page
		And Navigate to '<Mobile Poker>' page
		And I click '<Play New Poker>' button
		When I log in from Login Form using 'sqatmpoker' and 'Paroli1#'
		Then Mobile Poker game is launched
		And '<Url>' is correct
	Examples: 
	| Mobile Poker  | Play New Poker  | Url |
	| Mobile Poker	| Play New Poker  | https://poker.adjarabet.com/?https://launch.spribegaming.com/poker?brand=adjarabet.com&currency=GEL&game_id=poker&    |

	@Poker
	Scenario: Check Mobile Poker as not authorized user v2
		Given Open mobile Adjarabet page
		And Navigate to '<Mobile Poker>' page
		And I click '<Play New Poker>' button
		When I log in from Login Form using 'sqatmpoker' and 'Paroli1#'
		Then Game is launched
		And '<Url>' is correct
	Examples: 
	| Mobile Poker  | Play New Poker  | Url |
	| Mobile Poker	| Play New Poker  | https://poker.adjarabet.com/?https://launch.spribegaming.com/poker?brand=adjarabet.com&currency=GEL&game_id=poker&    |

	@Poker
	Scenario: Check Mobile Poker as a logged in user V2
		Given Open mobile Adjarabet page
		And Login on home page using 'sqatmpoker' and 'Paroli1#'
		And Navigate to '<Mobile Poker>' page
		When I click '<Play New Poker>' button
		Then Game is launched
		And '<Url>' is correct
	Examples: 
	| Mobile Poker  | Play New Poker  | Url |
	| Mobile Poker	| Play New Poker  | https://poker.adjarabet.com/?https://launch.spribegaming.com/poker?brand=adjarabet.com&currency=GEL&game_id=poker&    |
