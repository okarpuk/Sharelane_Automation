using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Sharelane_Automation.Pages
{
    public class HomePage : BasePage
    {
        By SearchFieldLocator = By.Name("keyword");
        By SearchButtonLocator = By.XPath("//input[@value='Search']");
        By TitleLengthLessThan4SymbolsLocator = By.XPath($"//*[@class='confirmation_message']");

        public HomePage(WebDriver driver) : base(driver) { }

        public void EnterBookTitle(string bookTitle)
        {
            ChromeDriver.FindElement(SearchFieldLocator).SendKeys(bookTitle);
        }

        public void SearchButtonClick()
        {
            ChromeDriver.FindElement(SearchButtonLocator).Click();
        }

        public BookPage SearchByBookTitle(string bookTitle)
        {
            EnterBookTitle(bookTitle);
            SearchButtonClick();
            return new BookPage(ChromeDriver);
        }

        public string TitleLengthLessThan4Symbols()
        {
            return ChromeDriver.FindElement(TitleLengthLessThan4SymbolsLocator).Text;
        }
    }
}
