using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageElements;
using SeleniumExtras.WaitHelpers;
using System;

namespace PageSteps
{
    public class LevelPageService
    {
        private LevelPageLocators _levelPageLocators;
        private WebDriverWait _driverWait;
        private TestData _testData;
        public LevelPageService(IWebDriver driver)
        {
            _levelPageLocators = new LevelPageLocators();
            _testData = new TestData();
            _driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(_testData.GLOBAL_TIMEOUT));
        }

        public string EnterLevelData(IWebDriver driver, int levelValue)
        {

            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_levelPageLocators.AddNewLevel)));
            driver.FindElement(By.XPath(_levelPageLocators.AddNewLevel)).Click();

            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.Id(_levelPageLocators.LevelInput)));
            driver.FindElement(By.Id(_levelPageLocators.LevelInput)).SendKeys(levelValue.ToString());

            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_levelPageLocators.SubmitLevel)));
            driver.FindElement(By.XPath(_levelPageLocators.SubmitLevel)).Click();

            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_levelPageLocators.LevelList)));
            string recentEntries = driver.FindElement(By.XPath(_levelPageLocators.LevelList)).Text;

            return recentEntries;
        }

        public void DeleteLevelValue(IWebDriver driver)
        {
            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_levelPageLocators.DeleteLevel)));

            driver.FindElement(By.XPath(_levelPageLocators.DeleteLevel)).Click();

            driver.SwitchTo().Alert().Accept();
            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_levelPageLocators.AddNewLevel)));
        }

        public string GetLevelData(IWebDriver driver)
        {
            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_levelPageLocators.LevelData)));

            return driver.FindElement(By.XPath(_levelPageLocators.LevelData)).Text;
        }
    }
}