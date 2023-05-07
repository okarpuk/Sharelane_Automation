using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Sharelane_Automation.Pages
{
    public class SignupPage : BasePage
    {
        By signUpLinkLocator = By.XPath("//a[text()='Sign up']");
        By zipCodeInputLocator = By.XPath("//input[@name='zip_code']");
        By continueButtonLocator = By.XPath("//input[@value='Continue']");
        By firstNameInputLocator = By.XPath("//input[@name='first_name']");
        By lastNameInputLocator = By.XPath("//input[@name='last_name']");
        By emailInputLocator = By.XPath("//input[@name='email']");
        By passwordInputLocator = By.XPath("//input[@name='password1']");
        By confirmPasswordInputLocator = By.XPath("//input[@name='password2']");
        By registerButtonLocator = By.XPath("//input[@value='Register']");
        By confirmationMessageLocator = By.XPath("//*[@class='confirmation_message']");
        By invalidValueLocator = By.XPath($"//*[@class='error_message']");
        By emailCreatedLocator = By.XPath("//td[preceding-sibling::td='Email']");

        public SignupPage(WebDriver driver) : base(driver) { }

        public void SignUpLinkClick()
        {
            Driver.FindElement(signUpLinkLocator).Click();
        }

        public void EnterZipCode(string zipCode)
        {
            Driver.FindElement(zipCodeInputLocator).SendKeys(zipCode);
        }

        public void ContinueButtonClick()
        {
            Driver.FindElement(continueButtonLocator).Click();
        }

        public void EnterFirstName(string firstName)
        {
            Driver.FindElement(firstNameInputLocator).SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            Driver.FindElement(lastNameInputLocator).SendKeys(lastName);
        }

        public void EnterEmail(string email)
        {
            Driver.FindElement(emailInputLocator).SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            Driver.FindElement(passwordInputLocator).SendKeys(password);
        }

        public void EnterConfirmPassword(string confirmPassword)
        {
            Driver.FindElement(confirmPasswordInputLocator).SendKeys(confirmPassword);
        }

        public void RegisterButtonClick()
        {
            Driver.FindElement(registerButtonLocator).Click();
        }

        public string DisplayConfirmationMessage()
        {
            return Driver.FindElement(confirmationMessageLocator).Text;
        }

        public string DisplayInvalidValueMessage()
        {
            return Driver.FindElement(invalidValueLocator).Text;
        }

        public void TestUserSignUp(string zipCode = "", string firstName = "", string lastName = "", string email = "", string password = "", string confirmPassword = "")
        {
            SignUpLinkClick();
            EnterZipCode(zipCode);
            ContinueButtonClick();
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterEmail(email);
            EnterPassword(password);
            EnterConfirmPassword(confirmPassword);
            RegisterButtonClick();
        }

        public string GenerateEmailForLogin()
        {
            TestUserSignUp("12345", "Testuser", email: "testuser@test.test", password: "12345", confirmPassword: "12345");
            return Driver.FindElement(emailCreatedLocator).Text;
        }
    }
}
