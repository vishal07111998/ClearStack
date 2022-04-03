using PageSteps;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Test
{
    [TestFixture]
    public class LevelTest
    {
        private IWebDriver _driver;
        private LoginPageService _loginPageServices;
        private HomePageService _homePageService;

        private LevelPageService _levelPageService;
        private TestData _testData;
        private bool _isPasswordDataAvailable = false;

        [SetUp]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _loginPageServices = new LoginPageService(_driver);
            _homePageService = new HomePageService(_driver);
            _levelPageService = new LevelPageService(_driver);
            _driver.Manage().Window.Maximize();
            _testData = new TestData();
            _driver.Url = _testData.Url;

        }

        // This Test Verifies That New Level Can Be added 
        [Test]
        public void ValidUser_AddNewLevel_VerifyLevelAdded()
        {
            string actualWelcomeText = _loginPageServices.LoginWithUsernameAndPassword(_driver);
         
            _homePageService.NavigateToAddNewLevelPage(_driver);

            Random random = new Random();
            int levelEntry = random.Next();
            string actualLevelTableText = _levelPageService.EnterLevelData(_driver, levelEntry);

            Assert.AreEqual(_testData.RecentEntries, actualLevelTableText, $"Actual Level Table Text {actualLevelTableText} where as Expected was {_testData.RecentEntries}");

            string actualLevelData = _levelPageService.GetLevelData(_driver);

            Assert.IsTrue(actualLevelData.Contains(levelEntry.ToString()), $"It Was Expected To Contain Value {levelEntry} Where As Actual Is {actualLevelData}");
        }

        [TearDown]
        public void CloseResources()
        {
            _levelPageService.DeleteLevelValue(_driver);
            _driver.Close();
        }
    }
}