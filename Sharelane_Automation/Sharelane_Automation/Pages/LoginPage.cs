using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Sharelane_Automation.Pages
{
    public class LoginPage : BasePage
    {
        By EmailFieldLocator = By.Name("email");
        By PasswordFieldLocator = By.Name("password");
        By LoginButtonLocator = By.XPath("//input[@value='Login']");
        By ErrorMessageLocator = By.ClassName("error_message");

        public LoginPage(WebDriver driver) : base(driver) { }

        public void EnterEmail(string email)
        {
            Driver.FindElement(EmailFieldLocator).SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            Driver.FindElement(PasswordFieldLocator).SendKeys(password);
        }

        public void LoginButtonClick()
        {
            Driver.FindElement(LoginButtonLocator).Click();
        }

        public void UserLogin(string email = "", string password = "")
        {
            Driver.Navigate().GoToUrl("https://www.sharelane.com/cgi-bin/main.py");
            EnterEmail(email);
            EnterPassword(password);
            LoginButtonClick();
        }

        public string GetErrorMessage()
        {
            Assert.That(Driver.FindElement(ErrorMessageLocator).Displayed);
            return Driver.FindElement(ErrorMessageLocator).Text;
        }
    }
}
