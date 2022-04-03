using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageElements;
using SeleniumExtras.WaitHelpers;
using System;

namespace PageSteps
{
    public class HomePageService
    {
        private HomePageLocators _homePageLocators;
        private WebDriverWait _driverWait;
        private TestData _testData;
        public HomePageService(IWebDriver driver)
        {
            _homePageLocators = new HomePageLocators();
            _testData = new TestData();
            _driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(_testData.GLOBAL_TIMEOUT));
        }

        public void NavigateToAddNewLevelPage(IWebDriver driver)
        {
            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.Id(_homePageLocators.Menu)));
            var sideMenu = driver.FindElements(By.XPath(_homePageLocators.Level));

            if(sideMenu.Count==0)   driver.FindElement(By.XPath(_homePageLocators.Menu)).Click();
            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_homePageLocators.Level)));

            driver.FindElement(By.XPath(_homePageLocators.Level)).Click();
        }

         public void NavigateToReportsPage(IWebDriver driver)
        {
            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.Id(_homePageLocators.Menu)));
            var sideMenu = driver.FindElements(By.XPath(_homePageLocators.Report));

            if(sideMenu.Count==0)   driver.FindElement(By.XPath(_homePageLocators.Menu)).Click();
            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_homePageLocators.Report)));

            driver.FindElement(By.XPath(_homePageLocators.Report)).Click();
        }


    }
}