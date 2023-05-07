using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Sharelane_Automation.Pages
{
    public class BookPage : BasePage
    {
        By AddToCardButtonLocator = By.XPath("//img[@src='../images/add_to_cart.gif']");

        public BookPage(WebDriver driver) : base(driver) { }

        public void AddToCartButtonClick()
        {
            Driver.FindElement(AddToCardButtonLocator).Click();
        }

        public bool IsAddToCardButtonDisplays()
        {
            return Driver.FindElement(AddToCardButtonLocator).Displayed;
        }
    }
}
