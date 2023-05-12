using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Sharelane_Automation.Pages
{
    public abstract class BasePage
    {
        public WebDriver Driver { get; set; }

        public BasePage(WebDriver driver)
        {
            Driver = driver;
        }
    }
}
