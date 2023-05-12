using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Sharelane_Automation.Pages;

namespace Sharelane_Automation.Tests
{
    public class SearchTest : BaseTest
    {
        public HomePage HomePage { get; set; }
        public BookPage BookPage { get; set; }

        [SetUp]
        public void SetUp()
        {
            HomePage = new HomePage(Driver);
            BookPage = new BookPage(Driver);
        }

        [Test]
        public void Search_Test_1_ValidBookTitle()
        {
            string bookTitle = "Great Expectations";
            HomePage.SearchByBookTitle(bookTitle);
            Assert.IsTrue(BookPage.IsAddToCardButtonDisplays());
        }

        [Test]
        public void Search_Test_2_BookTitleLengthLessThan4Symbols()
        {
            string bookTitle = "Qwe";
            var expectedMessage = "Please, note that current MySQL settings don't allow searches for words containing less than 4 chars";
            HomePage.SearchByBookTitle(bookTitle);
            Assert.That(expectedMessage, Is.EqualTo(HomePage.TitleLengthLessThan4Symbols()));
        }
    }
}
