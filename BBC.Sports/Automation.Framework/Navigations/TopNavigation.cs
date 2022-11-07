using Automation.Framework.Pages;
using OpenQA.Selenium;

namespace Automation.Framework.Navigations
{
    public class TopNavigation : BasePage
    {
        private IList<IWebElement> topNavigationMenu => driver.FindElements(By.XPath("//div[@id ='product-navigation-menu']/div[2]/ul//a/span"));

        private IList<IWebElement> secondaryNavigationMenu => driver.FindElements(By.XPath("//ul[@id ='sp-nav-secondary']/li/a"));

        public void Goto(string topMenu, string secondaryMenu)
        {
            topNavigationMenu.FirstOrDefault(menu => menu.Text == topMenu)?.Click();
            secondaryNavigationMenu.FirstOrDefault(menu => menu.Text == secondaryMenu)?.Click();
        }
    }
}
