using Automation.Framework.Utilities.Selenium.Utilities;
using TechTalk.SpecFlow;

namespace BBC.Sports.Automation.Tests.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            WebDriverHelper.StartWebDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriverHelper.QuitWebDriver();
        }
    }
}