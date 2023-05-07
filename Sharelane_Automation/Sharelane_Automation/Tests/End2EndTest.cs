using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Sharelane_Automation.Pages;

namespace Sharelane_Automation.Tests
{
    [TestFixture]
    public class End2EndTest : BaseTest
    {
        public HomePage HomePage { get; set; }
        public BookPage BookPage { get; set; }
        public CartPage CartPage { get; set; }
        public CheckoutPage CheckoutPage { get; set; }

        [SetUp]
        public void SetUp()
        {
            HomePage = new HomePage(Driver);
            BookPage = new BookPage(Driver);
            CartPage = new CartPage(Driver);
            CheckoutPage = new CheckoutPage(Driver);
            string email = SignupPage.GenerateEmailForLogin();
            string password = "1111";
            LoginPage.UserLogin(email, password);
        }

        [Test]
        public void End_To_End_Test_ValidValues()
        {
            string bookTitle = "The Moon and Sixpence";
            var quantity = 1;
            var cardType = "MasterCard";
            var cardNumber = "1111111111112957"; //need to change every 1 hour (https://sharelane.com/cgi-bin/get_credit_card.py)
            CartPage.AddBookToShoppingCart(bookTitle, quantity);
            CartPage.ProceedToCheckoutButtonClick();
            CheckoutPage.ChooseCardType(cardType);
            CheckoutPage.EnterCardNumber(cardNumber);
            CheckoutPage.ClickMakePaymentButton();
            Assert.IsTrue(CheckoutPage.IsOrderSuccessful());
            var orderId = CheckoutPage.IsOrderIdDisplays().Replace("Order id: ", "");
            Assert.IsNotEmpty(orderId);
        }
    }
}
