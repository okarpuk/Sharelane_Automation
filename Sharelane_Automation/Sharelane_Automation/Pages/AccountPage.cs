using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Sharelane_Automation.Pages
{
    public class AccountPage : BasePage
    {
        By LogoutLinkLocator = By.LinkText("Logout");

        public AccountPage(WebDriver driver) : base(driver)
        {
            Assert.IsTrue(IsLogoutLinkDisplays());
        }

        public bool IsLogoutLinkDisplays()
        {
            return ChromeDriver.FindElement(LogoutLinkLocator).Displayed;
        }
    }
}
