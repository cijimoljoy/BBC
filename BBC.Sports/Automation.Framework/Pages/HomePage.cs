namespace Automation.Framework.Pages
{
    public class HomePage : BasePage
    {
        private string pageUrl = "https://www.bbc.co.uk/sport";
        public bool IsAtHomePage()
        {
            if (driver.Url.Equals(pageUrl))
            {
                return true;
            }
            return false;
        }
    }
}
