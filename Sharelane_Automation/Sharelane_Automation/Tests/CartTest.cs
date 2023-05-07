using Core.Utilites;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Sharelane_Automation.Pages;

namespace Sharelane_Automation.Tests
{
    public class CartTest : BaseTest
    {
        public HomePage HomePage { get; set; }
        public BookPage BookPage { get; set; }
        public CartPage CartPage { get; set; }

        [SetUp]
        public void SetUp()
        {
            HomePage = new HomePage(Driver);
            BookPage = new BookPage(Driver);
            CartPage = new CartPage(Driver);
            var standartUser = UserBuilder.StandartUser;
            string email = SignupPage.GenerateEmailForLogin();
            LoginPage.UserLogin(email, standartUser.Password);
        }

        [TestCase("The Power", 1, 0)]
        [TestCase("The Power", 19, 0)]
        [TestCase("The Power", 20, 2)]
        [TestCase("The Power", 49, 2)]
        [TestCase("The Power", 50, 3)]
        [TestCase("The Power", 99, 3)]
        [TestCase("The Power", 100, 4)]
        [TestCase("The Power", 499, 4)]
        [TestCase("The Power", 500, 5)]
        [TestCase("The Power", 999, 5)]
        [TestCase("The Power", 1000, 6)]
        [TestCase("The Power", 4999, 6)]
        [TestCase("The Power", 5000, 7)]
        [TestCase("The Power", 9999, 7)]
        [TestCase("The Power", 10000, 8)]
        
        [Test]
        public void Shopping_Cart_Test_1_IsDiscountPercentCorrect(string bookTitle, int quantity, decimal discountPercentExpected)
        {
            CartPage.AddBookToShoppingCart(bookTitle, quantity);
            decimal discountPercentActual = Convert.ToDecimal(CartPage.PercentDiscount());
            Assert.That(discountPercentActual, Is.EqualTo(discountPercentExpected));
        }

        [Test]
        public void Shopping_Cart_Test_2_IsDiscountValueCorrect()
        {
            string bookTitle = "The Moon and Sixpence";
            int quantity = 1;
            CartPage.AddBookToShoppingCart(bookTitle, quantity);
            decimal priceActual = Convert.ToDecimal(CartPage.Price());
            decimal discountPercentActual = Convert.ToDecimal(CartPage.PercentDiscount());
            decimal discountValueActual = Convert.ToDecimal(CartPage.ValueDiscount());
            decimal discountValueExpected = priceActual * Convert.ToDecimal(quantity) * discountPercentActual / 100;
            Assert.That(discountValueActual, Is.EqualTo(discountValueExpected));
        }

        [Test]
        public void Shopping_Cart_Test_3_IsTotalPriceCorrect()
        {
            string bookTitle = "The Moon and Sixpence";
            int quantity = 1;
            CartPage.AddBookToShoppingCart(bookTitle, quantity);
            decimal priceActual = Convert.ToDecimal(CartPage.Price());
            decimal discountPercentActual = Convert.ToDecimal(CartPage.PercentDiscount());
            decimal totalPriceActual = Convert.ToDecimal(CartPage.TotalPrice());
            decimal discountValueExpected = priceActual * Convert.ToDecimal(quantity) * discountPercentActual / 100;
            decimal totalPriceExpected = priceActual * Convert.ToDecimal(quantity) - discountValueExpected;
            Assert.That(totalPriceActual, Is.EqualTo(totalPriceExpected));
        }
    }
}
