using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageElements;
using SeleniumExtras.WaitHelpers;
using System;

namespace PageSteps
{
    public class ReportPageService
    {
        private ReportPageLocators _reportPageLocators;
        private WebDriverWait _driverWait;
        private TestData _testData;
        public ReportPageService(IWebDriver driver)
        {
            _reportPageLocators = new ReportPageLocators();
            _testData = new TestData();
            _driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(_testData.GLOBAL_TIMEOUT));
        }

        public string GetReportText(IWebDriver driver)
        {
            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_reportPageLocators.LevelReports)));

            return driver.FindElement(By.XPath(_reportPageLocators.LevelReports)).Text;
        }

        public string GetReportValue(IWebDriver driver)
        {
            _driverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(_reportPageLocators.ReportLevelValue)));

            return driver.FindElement(By.XPath(_reportPageLocators.ReportLevelValue)).Text;
        }

    }
}