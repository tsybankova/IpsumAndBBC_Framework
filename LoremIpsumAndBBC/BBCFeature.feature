Feature: BBCFeature

Scenario: Check Headline Article Title
	When I Get the Html Document from BBC News Page $
	Then The Headline Article title is UK PM's aide to speak shortly on lockdown row

Scenario: Check Secondary Articles Titles
	When I Get the Html Document from BBC News Page $
	Then Secondary Articles titles are
	| Article Title                                      |
	| Americans flock to beaches on Memorial Day weekend |
	| Fancy a pint? Five ways Europe is easing lockdown  |
	| Top exiled Saudi officer 'targeted through family' |
	| Ardern takes mid-interview quake in her stride     |
	| Brian May 'could have died' after heart attack     | 

Scenario: Check First Article Title among the List Got by Search
	When I Get the Headline Article Category
	Then The First Article Title in Category Search Results List is World's End: World's End

Scenario Outline: Populate Feedback with Data and Take Screenshot 
	Given I am on Contact BBC page
	When I select Comment on BBC Website Category
	And I Generate <Text Size> Text at BaseballIpsum site $
	And I Populate Comment with <Text Size> Feedback $
	| Url            | Subject						| Is Confirmation Letter Needed |
	| www.google.com | Some very important comment  | false                         |
	Then Generated and Submitted Text Lengths are equal: <text lengths are equal> $
	And I Take a Screenshot
	Examples:
	| Text Size      | text lengths are equal |
	| Properly Sized | true                   |
	| Too Long       | false                  |

Scenario: Populate Feedback with Incorrect Data and Get Error Message 
	Given I am on Contact BBC page
	When I select Comment on BBC Website Category
	And I Generate Properly Sized Text at BaseballIpsum site $
	And I Submit Comment with Some Empty Fields
	| Url            | Subject   | Is Confirmation Letter Needed |
	| www.google.com |			 | true                          |
	Then Error Banner is Displayed



