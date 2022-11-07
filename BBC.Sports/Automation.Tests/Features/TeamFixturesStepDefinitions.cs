using Automation.Framework.Navigations;
using Automation.Framework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Automation.Tests.Features
{
    [Binding]
    public class TeamFixturesStepDefinitions
    {
        private string? selectedTeam;
        private List<string>? bottomTeamList;

        [Given(@"I have reached the BBC sports homepage")]
        public void GivenIHaveReachedTheBbcSportsHomepage()
        {
            Assert.IsTrue(new HomePage().IsAtHomePage());
        }

        [When(@"I have found the bottom half of the table")]
        public void WhenIHaveFoundTheBottomHalfOfTheTable()
        {
            new TopNavigation().Goto("Football", "Tables");
            bottomTeamList = new TablesPage().FindBottomTeamList();
        }

        [When(@"I have selected the top menu '([^']*)' and secondary menu '([^']*)'")]
        public void WhenIHaveSelectedTheTopMenuAndSecondaryMenu(string topmenu, string secondaryMenu)
        {
            new TopNavigation().Goto(topmenu, secondaryMenu);
        }

        [When(@"I have searched and selected the team '([^']*)'")]
        public void WhenIHaveSearchedAndSelectedTheTeam(string team)
        {
            new FixturesPage().SelectTeam(team);
            selectedTeam = team;
        }

        [Then(@"I could see easy teams highlighted in next '([^']*)' upcoming matches for the competition '([^']*)'")]
        public void ThenICouldSeeEasyTeamsHighlightedInNextUpcomingMatchesForTheCompetition(int count, string competition)
        {
            if (selectedTeam != null && bottomTeamList != null)
            {
                new FixturesPage().DetermineFixtures(selectedTeam, competition, count, bottomTeamList);
            }
        }

    }
}
