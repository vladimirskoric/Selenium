using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using TestHelper;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    [TestFixture]
    public class SeleniumTests
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _driver = new InternetExplorerDriver();
        }
   
        private void GoToUrl(string url)
        {
           _driver.Navigate().GoToUrl(url);
        }

        [Test]
        public void Login()
        {
            GoToUrl("http://executeautomation.com/demosite/Login.html");
            var userName = _driver.FindElement(By.Name("UserName"));
            var passWord = _driver.FindElement(By.Name("Password"));
            var loginButton = _driver.FindElement(By.Name("Login"));

            userName.SendKeys("sophos");
            passWord.SendKeys("makati");
            loginButton.Submit();
        }

        [Test]
        public void LoginPageObjeect()
        {
            LoginPage page = new LoginPage(_driver, "http://executeautomation.com/demosite/Login.html");
            page.Login("sophos", "makati");
        }

        [Test]
        public void UserForm()
        {
            GoToUrl("http://executeautomation.com/demosite/index.html");
            var title = _driver.FindElement(By.Name("TitleId"));
            new SelectElement(title).SelectByText("Mr.");

            var initial = _driver.FindElement(By.Name("Initial"));
            initial.SendKeys("JZ");

            var firstName = _driver.FindElement(By.Name("FirstName"));
            firstName.SendKeys("Jake");

            var lastName = _driver.FindElement(By.Name("MiddleName"));
            lastName.SendKeys("Pacquio");

        }

    }
}
