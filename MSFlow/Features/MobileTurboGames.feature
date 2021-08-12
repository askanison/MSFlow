Feature: MobileTurboGames

@Mobile
Scenario: Check mobile Turbo Games as a logged in user
	Given Open mobile Adjarabet page
	And Login on home page using 'sqatmturbo' and 'Paroli1#'
	And Navigate to mobile Turbo Games page
	When I click '<Turbo Game>' button 
	Then Turbo Game is launched
	And '<Url>' is correct

Examples: 
	| Turbo Game    | Url                                                          |
	| Plinko        | https://spgames.adjarabet.com/turbo/play/plinko?user=        |
	| Mines         | https://spgames.adjarabet.com/turbo/play/mines?user=         |
	| Goal          | https://spgames.adjarabet.com/turbo/play/goal?user=          |
	| HiLo          | https://spgames.adjarabet.com/turbo/play/hi-lo?user=         |
	| Dice          | https://spgames.adjarabet.com/turbo/play/dice?user=          |
	| Mini Roulette | https://spgames.adjarabet.com/turbo/play/mini-roulette?user= |

@Mobile
Scenario: Check mobile Turbo Games as a not logged in user
	Given Open mobile Adjarabet page
	And Navigate to mobile Turbo Games page
	And I click '<Turbo Game>' button
	When I log in from Login Form
	Then Turbo Game is launched
	And '<Url>' is correct

 Examples: 
	| Turbo Game    | Url                                                          |
	| Plinko        | https://spgames.adjarabet.com/turbo/play/plinko?user=        |
	| Mines         | https://spgames.adjarabet.com/turbo/play/mines?user=         |
	| Goal          | https://spgames.adjarabet.com/turbo/play/goal?user=          |
	| HiLo          | https://spgames.adjarabet.com/turbo/play/hi-lo?user=         |
	| Dice          | https://spgames.adjarabet.com/turbo/play/dice?user=          |
	| Mini Roulette | https://spgames.adjarabet.com/turbo/play/mini-roulette?user= |