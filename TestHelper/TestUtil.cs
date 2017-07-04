using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHelper
{
    public static class TestUtil
    {
        #region helpers

        public static void EnterText(IWebDriver driver, string element, string value, string elementType)
        {
            if (elementType == "Id")
                driver.FindElement(By.Id(element)).SendKeys(value);

            if (elementType == "Name")
                driver.FindElement(By.Name(element)).SendKeys(value);

        }

        public static void Click(IWebDriver driver, string element, string elementType)
        {
            if (elementType == "Id")
                driver.FindElement(By.Id(element)).Click();

            if (elementType == "Name")
                driver.FindElement(By.Name(element)).Submit();
        }

        public static void SelectDropdown(IWebDriver driver, string element, string value, string elementType)
        {
            if (elementType == "Id")
                new SelectElement(driver.FindElement(By.Id(element))).SelectByValue(value);

            if (elementType == "Name")
                new SelectElement(driver.FindElement(By.Name(element))).SelectByValue(value);
        }

        public static void GetText(IWebDriver driver, string element, string elementType)
        {
            if (elementType == "Id")
                driver.FindElement(By.Id(element)).GetAttribute("value");

            if (elementType == "Name")
                driver.FindElement(By.Name(element)).GetAttribute("value");
        }

        public static string GetTextFromDDL(IWebDriver driver, string element, string elementType)
        {
            if (elementType == "Id")
                return new SelectElement(driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;

            if (elementType == "Name")
                return new SelectElement(driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;

            return String.Empty;
        }

        #endregion
    }

    public class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How= How.Name, Using = "UserName")]
        private IWebElement Username { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = "Login")]
        private IWebElement btnLogin { get; set; }

        public void Login(string username, string password)
        {
            Username.SendKeys("sophos");
            Password.SendKeys("makati");
            btnLogin.Submit();
        }
    }
}
