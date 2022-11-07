using OpenQA.Selenium;

namespace Automation.Framework.Pages
{
    public class TablesPage : BasePage
    {
        private IList<IWebElement> teamList => driver.FindElements(By.XPath("//table/tbody/tr//abbr"));

        public List<string> FindBottomTeamList()
        {
            var list = teamList.TakeLast(10).Select(ele => ele.GetAttribute("title")).ToList();
            return list;
        }
    }
}
