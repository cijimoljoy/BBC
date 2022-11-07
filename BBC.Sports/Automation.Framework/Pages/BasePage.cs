using Automation.Framework.Utilities.Selenium.Utilities;
using OpenQA.Selenium;

namespace Automation.Framework.Pages
{
    public class BasePage
    {
        public IWebDriver driver;
        public BasePage()
        {
            driver = WebDriverHelper.driver;
        }
    }
}
