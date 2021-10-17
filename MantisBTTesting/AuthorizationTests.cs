using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MantisBTTesting.PageObjects;
using System.Threading;

namespace MantisBTTesting.AutorizationTests
{
    [TestFixture]
    public class AuthorizationTests 
    {
        private IWebDriver webDriver;
        private HomePage homePage;
        private LoginPage loginPage;
        private PasswordPage passwordPage;

        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Cookies.DeleteAllCookies();
            homePage = new HomePage(webDriver);
            loginPage = homePage.GoToLoginPage();
        }

        #region positive testing

        [Test] 
        public void T1_Authorization_PositiveTest()
        {
            passwordPage = loginPage.SendUsername(User.name);
            passwordPage.SendPassword(User.pass);
            Thread.Sleep(500);

            Assert.AreEqual(homePage.GetUsername(), User.name);

            homePage.Logout();
        }

        [Test]
        public void T2_AnonAuthorization_PositiveTest()
        {
            loginPage.LoginAnon();

            Assert.AreEqual(homePage.GetUsername(), "anonymous");
        }

        #endregion

        #region negative testing

        [TestCase("")]
        public void T3_EmptyPassword_NegativeTest(string password)
        {
            passwordPage = loginPage.SendUsername(User.name);
            passwordPage.SendPassword(password);
            Thread.Sleep(500);

            Assert.IsTrue(Warning.IsExist(webDriver));
        }

        [TestCase("aaaaaa")]
        public void T4_WrongPassword_NegativeTest(string password)
        {
            passwordPage = loginPage.SendUsername(User.name);
            passwordPage.SendPassword(password);

            Assert.IsTrue(Warning.IsExist(webDriver));
        }

        [Test]
        public void T5_EmptyUsername_NegativeTest()
        {
            PasswordPage password = loginPage.SendUsername("");
            Thread.Sleep(500);

            Assert.IsTrue(Warning.IsExist(webDriver));
        }

        #endregion

        [TearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }
    }
}