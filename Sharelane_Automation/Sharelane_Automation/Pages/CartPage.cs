using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Sharelane_Automation.Pages;

namespace Sharelane_Automation.Pages
{
    public class CartPage : BasePage
    {

        By shoppingCartLinkLocator = By.XPath("//a[@href='./shopping_cart.py']");
        By quantityFieldLocator = By.Name("q");
        By updateButtonLocator = By.XPath("//input[@value='Update']");
        By priceLocator = By.XPath("//tr[2]/td[4]");
        By percentDiscountLocator = By.XPath("//td[5]/p/b");
        By valueDiscountLocator = By.XPath("//tr[2]/td[6]");
        By totalLocator = By.XPath("//tr[2]/td[7]");
        By proceedToCheckoutButtonLocator = By.XPath("//input[@value='Proceed to Checkout']");

        public CartPage(WebDriver driver) : base(driver) { }

        public void ShoppingCartLinkClick()
        {
            ChromeDriver.FindElement(shoppingCartLinkLocator).Click();
        }

        public void QuantityInput(int quantity)
        {
            ChromeDriver.FindElement(quantityFieldLocator).Clear();
            ChromeDriver.FindElement(quantityFieldLocator).SendKeys(Convert.ToString(quantity));
        }

        public void UpdateButtonClick()
        {
            ChromeDriver.FindElement(updateButtonLocator).Click();
        }

        public void ProceedToCheckoutButtonClick()
        {
            ChromeDriver.FindElement(proceedToCheckoutButtonLocator).Click();
        }

        public string Price()
        {
            return ChromeDriver.FindElement(priceLocator).Text.Replace(".", ",");
        }

        public string PercentDiscount()
        {
            return ChromeDriver.FindElement(percentDiscountLocator).Text;
        }

        public string ValueDiscount()
        {
            return ChromeDriver.FindElement(valueDiscountLocator).Text.Replace(".", ",");
        }

        public string TotalPrice()
        {
            return ChromeDriver.FindElement(totalLocator).Text.Replace(".", ",");
        }

        public void AddBookToShoppingCart(string bookName, int quantity)
        {
            new HomePage(ChromeDriver).SearchByBookTitle(bookName);
            new BookPage(ChromeDriver).AddToCartButtonClick();
            ShoppingCartLinkClick();
            QuantityInput(quantity);
            UpdateButtonClick();
        }
    }
}
