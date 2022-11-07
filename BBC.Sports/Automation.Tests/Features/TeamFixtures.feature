Feature: BBC Team Fixtures

Scenario: Determine the easy games from the upcoming matches in a football competition
Given I have reached the BBC sports homepage
When I have found the bottom half of the table
And I have selected the top menu 'Football' and secondary menu 'Scores & Fixtures'
And I have searched and selected the team 'Tottenham Hotspur'
Then I could see easy teams highlighted in next '5' upcoming matches for the competition 'Premier League'

