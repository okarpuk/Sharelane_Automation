using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Sharelane_Automation.Pages;

namespace Sharelane_Automation.Tests
{
    [TestFixture]

    public class SignupTest : BaseTest
    {
        [Test]
        public void SignUp_Test_1_EnterValidValues()
        {
            string zipCode = "12345";
            string firstName = "Test";
            string lastName = "User";
            string email = "test@test.test";
            string password = "1234";
            string confirmPassword = "1234";
            string expectedConfirmationMessage = "Account is created!";
            SignupPage.TestUserSignUp(zipCode, firstName, lastName, email, password, confirmPassword);
            Assert.That(SignupPage.DisplayConfirmationMessage(), Is.EqualTo(expectedConfirmationMessage));
        }

        [Test]
        public void SignUp_Test_2_EnterInvalidValue()
        {
            string zipCode = "12345";
            string firstName = "Test";
            string lastName = "User";
            string email = "test@test@test";
            string password = "1234";
            string confirmPassword = "1234";
            var expectedMessage = "Oops, error on page. Some of your fields have invalid data or email was previously used";
            SignupPage.TestUserSignUp(zipCode, firstName, lastName, email, password, confirmPassword);
            Assert.That(expectedMessage, Is.EqualTo(SignupPage.DisplayInvalidValueMessage()));
        }
    }
}
