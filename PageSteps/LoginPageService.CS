using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageElements;
using SeleniumExtras.WaitHelpers;
using System;

namespace PageSteps
{
    public class LoginPageService
    {
        private LoginPageLocators _loginPageLocators;
        private HomePageLocators _homePageLocators;
        private WebDriverWait _driverWait;
        private TestData _testData;
        public LoginPageService(IWebDriver driver)
        {
            _loginPageLocators = new LoginPageLocators();
            _homePageLocators= new HomePageLocators();
            _testData = new TestData();
            _driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(_testData.GLOBAL_TIMEOUT));
        }
        public string LoginWithUsernameAndPassword(IWebDriver driver)
        {
            // Enter UserName Or Email On Password Login Page
            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.Id(_loginPageLocators.LoginUserName)));
            IWebElement element = driver.FindElement(By.Id(_loginPageLocators.LoginUserName));
            element.SendKeys(_testData.LoginUserName);

            // Enter Password On Password Login Page
            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.Id(_loginPageLocators.LoginUserPassword)));
            driver.FindElement(By.Id(_loginPageLocators.LoginUserPassword)).SendKeys(_testData.LoginUserPassword);

            // Login Into App
            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_loginPageLocators.LoginButton)));
            driver.FindElement(By.XPath(_loginPageLocators.LoginButton)).Click();

            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_homePageLocators.WelcomeElement)));
            string actualWelcomeText=driver.FindElement(By.XPath(_homePageLocators.WelcomeElement)).Text;
            return actualWelcomeText;
        }
       
    }
}