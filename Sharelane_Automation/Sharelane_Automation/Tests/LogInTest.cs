using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Sharelane_Automation.Pages;

namespace Sharelane_Automation.Tests
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        [Test]
        public void Login_Test_1_ValidLoginAndPassword()
        {
            string email = SignupPage.GenerateEmailForLogin();
            string password = "1111";
            LoginPage.UserLogin(email, password);
            var accountPage = new AccountPage(Driver);
            Assert.IsTrue(accountPage.IsLogoutLinkDisplays());
        }

        [Test]
        public void Login_Test_2_InvalidEmail()
        {
            string email = "test@@test.test";
            string password = "1111";
            string errorText = "Oops, error. Email and/or password don't match our records";
            LoginPage.UserLogin(email, password);
            Assert.AreEqual(LoginPage.GetErrorMessage(), errorText);
        }

        [Test]
        public void Login_Test_3_InvalidPassword()
        {
            string email = SignupPage.GenerateEmailForLogin();
            string password = "12345";
            string errorText = "Oops, error. Email and/or password don't match our records";
            LoginPage.UserLogin(password: password);
            Assert.AreEqual(LoginPage.GetErrorMessage(), errorText);
        }
    }
}
