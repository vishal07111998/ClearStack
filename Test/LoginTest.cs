using PageSteps;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test
{
    [TestFixture]
    public class LoginTest
    {
      private  IWebDriver _driver;
      private  LoginPageService _loginPageServices;
      private  TestData _testData;
      private  bool _isPasswordDataAvailable = false;

        [SetUp]
        public void Initialize()
        {
            _driver = new ChromeDriver();
            _loginPageServices = new LoginPageService(_driver);
          
            _driver.Manage().Window.Maximize();
            _testData = new TestData();
            _driver.Url = _testData.Url;
           
        }

        // This Test Verifies That A Valid User Can Login Into app
        [Test]
        public void ValidUser_LoginIntoApp_SuccessfullyLogin()
        {
          string actualWelcomeText= _loginPageServices.LoginWithUsernameAndPassword(_driver,_testData.LoginUserName,_testData.LoginUserPassword);
          Assert.AreEqual(_testData.WelcomeText,actualWelcomeText,
          $"Expected Welcome Text {_testData.WelcomeText} Where As Actual Text {actualWelcomeText}");
        }

        [TearDown]
        public void CloseResources()
        {
            _driver.Close();
        }
    }
}