using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Sharelane_Automation.Pages
{
    public class CheckoutPage : BasePage
    {
        By makePaymentButtonLocator = By.XPath("//input[@value='Make Payment']");
        By cardTypeDropDownLocator = By.XPath("//select[@name='card_type_id']");
        By cardNumberFieldLocator = By.XPath("//input[@name='card_number']");
        By successfulOrderMessageLocator = By.XPath("//p[.='Thank you for your order!!!']");
        By orderIdLocator = By.XPath("//p[contains(text(), 'Order id:')]");

        public CheckoutPage(WebDriver driver) : base(driver) { }

        public void ChooseCardType(string selection)
        {
            var dropDown = Driver.FindElement(cardTypeDropDownLocator);
            var selectType = new SelectElement(dropDown);
            selectType.SelectByText(selection);
        }

        public void EnterCardNumber(string cardNumber)
        {
            Driver.FindElement(cardNumberFieldLocator).SendKeys(cardNumber);
        }

        public void ClickMakePaymentButton()
        {
            Driver.FindElement(makePaymentButtonLocator).Click();
        }

        public bool IsOrderSuccessful()
        {
            return Driver.FindElement(successfulOrderMessageLocator).Displayed;
        }

        public string IsOrderIdDisplays()
        {
            var orderId = Driver.FindElement(orderIdLocator).Text;
            return orderId;
        }
    }
}
