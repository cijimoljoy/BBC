using OpenQA.Selenium;

namespace Automation.Framework.Pages
{
    public class FixturesPage : BasePage
    {
        private IWebElement searchBox => driver.FindElement(By.XPath("//input[@name='search']"));
        private IWebElement currentDate => driver.FindElement(By.XPath("//ul[@id='sp-timeline-current-dates']/li/a/span[2][text()='FIXTURES']"));
        private IList<IWebElement> futureDates => driver.FindElements(By.XPath("//ul[@id='sp-timeline-future-dates']/li/a"));
        private IList<IWebElement> fixtures => driver.FindElements(By.XPath("//span[@role='region']/div/div"));

        private List<IWebElement> FindMatchingFixtures(string competition, IWebElement fixtureDate)
        {
            fixtureDate.Click();
            var matchingFixtures = fixtures.Where(fixture => fixture.GetAttribute("data-reactid").Contains(competition)).ToList();
            return matchingFixtures;
        }

        public void SelectTeam(string team)
        {
            searchBox.SendKeys(team);
            var teamLink = driver.FindElement(By.CssSelector($"a[data-reactid$='{team}.0']"));
            teamLink.Click();
        }

        public void DetermineFixtures(string team, string competition, int count, List<string> bottomList)
        {
            var fixtureDatesToCheck = new List<IWebElement>();
            fixtureDatesToCheck.Add(currentDate);
            fixtureDatesToCheck.AddRange(futureDates);


            foreach (var dateToCheck in fixtureDatesToCheck)
            {
                var matchingFixtures = FindMatchingFixtures(competition, dateToCheck);

                foreach (IWebElement fixture in matchingFixtures)
                {
                    var opponentTeam = fixture.FindElements(By.XPath(".//span/span/abbr")).Where(ele => ele.GetAttribute("title") != team).FirstOrDefault();
                    if (opponentTeam != null && bottomList.Contains(opponentTeam.GetAttribute("title")))
                    {
                        var jsDriver = (IJavaScriptExecutor)driver;
                        string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: red"";";
                        jsDriver.ExecuteScript(highlightJavascript, new object[] { opponentTeam.FindElement(By.XPath(".//ancestor::div[@class='qa-match-block']")) });
                    }
                    count--;

                    //To get some time for the visibility of the highlighted team
                    Thread.Sleep(2000);

                    if (count == 0) return;
                }
            }
        }
    }
}
