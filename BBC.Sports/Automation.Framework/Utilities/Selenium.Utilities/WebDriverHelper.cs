using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Automation.Framework.Utilities.Selenium.Utilities
{
    public class WebDriverHelper
    {
        public static IWebDriver? driver;

        public static BrowserTypes _selectedBrowser;

        public static IWebDriver StartWebDriver()
        {
            driver = OpenWebDriver();
            //Hard coding(Need to read from the config file)
            driver.Url = "https://www.bbc.co.uk/sport";

            //Hard coding(Need to read from the config file)
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

        public static void QuitWebDriver()
        {
            if (driver != null)
                driver.Quit();
        }

        private static IWebDriver OpenWebDriver()
        {
            //Hardcoding the selected browser as chrome, ideally would read it from config or settings file
            _selectedBrowser = (BrowserTypes)Enum.Parse(typeof(BrowserTypes), "Chrome");

            switch (_selectedBrowser)
            {
                case BrowserTypes.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserTypes.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new Exception($"Unknown Browser {_selectedBrowser} selected");
            }
            return driver;
        }
    }
}
