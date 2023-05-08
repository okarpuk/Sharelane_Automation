using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Sharelane_Automation.Pages;
using Core.Utilites;

namespace Sharelane_Automation.Tests
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        [Test]
        public void Login_Test_1_ValidLoginAndPassword()
        {
            var standartUser = UserBuilder.StandartUser;
            string email = SignupPage.GenerateEmailForLogin();
            LoginPage.UserLogin(email, standartUser.Password);
            var accountPage = new AccountPage(Driver);
            Assert.IsTrue(accountPage.IsLogoutLinkDisplays());
        }

        [Test]
        public void Login_Test_2_InvalidEmail()
        {
            var standartUser = UserBuilder.StandartUser;
            string errorText = "Oops, error. Email and/or password don't match our records";
            LoginPage.UserLogin(standartUser.InvalidName, standartUser.Password);
            Assert.AreEqual(LoginPage.GetErrorMessage(), errorText);
        }

        [Test]
        public void Login_Test_3_InvalidPassword()
        {
            var standartUser = UserBuilder.StandartUser;
            string email = SignupPage.GenerateEmailForLogin();
            string errorText = "Oops, error. Email and/or password don't match our records";
            LoginPage.UserLogin(email, standartUser.InvalidPassword);
            Assert.AreEqual(LoginPage.GetErrorMessage(), errorText);
        }
    }
}
