Feature: MobileTableGames

@Mobile
Scenario: Check mobile Table Games as a logged in user
	Given Open mobile Adjarabet page
	And Login on home page using 'sqatmp2p' and 'Paroli1#'
	And Navigate to mobile Table Games page
	When I click '<Table Game>' button 
	Then Table Game is launched
	And '<Url>' is correct

Examples: 
	| Table Game    | Url																					|
	| Dominoes      | https://p2p.adjarabet.com/?https://spgames.adjarabet.com/p2p/lobby/domino?user=       |
	| Bura			| https://p2p.adjarabet.com/?https://spgames.adjarabet.com/p2p/lobby/bura?user=         |
	| Backgammon    | https://p2p.adjarabet.com/?https://spgames.adjarabet.com/p2p/lobby/backgammon?user=   |
	| Seka          | https://p2p.adjarabet.com/?https://spgames.adjarabet.com/p2p/lobby/seka?user=		    |
