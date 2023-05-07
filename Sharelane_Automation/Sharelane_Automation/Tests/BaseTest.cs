using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Sharelane_Automation.Pages;

namespace Sharelane_Automation.Tests
{
    public class BaseTest
    {
        public WebDriver Driver { get; set; }
        public LoginPage LoginPage { get; set; }
        public SignupPage SignupPage { get; set; }

        [SetUp]
        public void SetUp()
        {
            switch ("Browser")
            {
                case "FireFox":
                    Driver = new FirefoxDriver();
                    break;
                default:
                    Driver = new ChromeDriver();
                    break;
            }

            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            Driver.Navigate().GoToUrl("https://sharelane.com/cgi-bin/main.py");
            LoginPage = new LoginPage(Driver);
            SignupPage = new SignupPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}