using PageSteps;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ClearStack.Test
{
    public class ReportTest
    {
        private IWebDriver _driver;
        private LoginPageService _loginPageServices;
        private HomePageService _homePageService;
        private LevelPageService _levelPageService;

        private ReportPageService _reportPageService;
        private TestData _testData;
        private bool _isPasswordDataAvailable = false;

        [SetUp]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _loginPageServices = new LoginPageService(_driver);
            _homePageService = new HomePageService(_driver);
            _levelPageService = new LevelPageService(_driver);
            _reportPageService = new ReportPageService(_driver);
            _driver.Manage().Window.Maximize();
            _testData = new TestData();
            _driver.Url = _testData.Url;
            string actualWelcomeText = _loginPageServices.LoginWithUsernameAndPassword(_driver, _testData.LoginUserName, _testData.LoginUserPassword);
            _homePageService.NavigateToAddNewLevelPage(_driver);

        }

        [Test]
        public void ValidUser_ViewReports_DataVisible()
        {
            Random random = new Random();
            int levelEntry = random.Next();
            _levelPageService.EnterLevelData(_driver, levelEntry);

            _homePageService.NavigateToReportsPage(_driver);
            string actualReportText = _reportPageService.GetReportText(_driver);
            Assert.AreEqual(_testData.LevelReports, actualReportText, $"Expected Text {_testData.LevelReports} where as Actual Text is {actualReportText}");

            string actualReportValue = _reportPageService.GetReportValue(_driver);
            Assert.AreEqual(levelEntry.ToString(), actualReportValue, $"Expected Value For Report {levelEntry} Where as Actual Text {actualReportValue}");
        }

        [TearDown]
        public void CloseResources()
        {
            _homePageService.NavigateToAddNewLevelPage(_driver);
            _levelPageService.DeleteLevelValue(_driver);
            _driver.Close();
        }
    }
}