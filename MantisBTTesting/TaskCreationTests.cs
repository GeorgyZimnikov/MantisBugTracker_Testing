using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MantisBTTesting.PageObjects;

namespace MantisBTTesting.TaskCreationTests
{
    [TestFixture]
    public class TaskCreationTests
    {
        private IWebDriver webDriver;
        private HomePage homePage;
        private LoginPage loginPage;
        private PasswordPage passwordPage;
        private ProjectSelectPage selectPage;
        private BugReportPage bugReportPage;

        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Cookies.DeleteAllCookies();

            homePage = new HomePage(webDriver);
            loginPage = homePage.GoToLoginPage();
            passwordPage = loginPage.SendUsername(User.name);
            passwordPage.SendPassword(User.pass);
            selectPage = homePage.GoToProjectSelectPage();
            bugReportPage = selectPage.Submit();
        }

        #region Positive testing

        [Test]
        public void T6_ValidTaskCreation_PositiveTest()
        {
            string currentUrl = webDriver.Url;

            bugReportPage.SelectCategory("sql");
            bugReportPage.SetSummary("Test_task_"+RandomString.Create(20));
            bugReportPage.SetDescription("Test_description_"+RandomString.Create(40));
            bugReportPage.setVisibility_private();
            bugReportPage.Submit();

            Assert.AreNotEqual(currentUrl, webDriver.Url);
        }

        [TestCase(128)]
        [TestCase(129)]
        [TestCase(200)]
        public void T7_SummaryStringLength_LessOrEqual128(int length)
        {
            bugReportPage.SetSummary(RandomString.Create(length));
            
            int stringLength = bugReportPage.SummaryLength();
            
            Assert.LessOrEqual(stringLength, 128);
        }

        #endregion

        #region Negative testing

        [Test]
        public void T8_EmptyTaskCreation_NegativeTest()
        {
            string currentUrl = webDriver.Url;

            bugReportPage.Submit();
            
            Assert.AreEqual(currentUrl, webDriver.Url);
        }

        [Test]
        public void T9_FillingSummaryWithSpaces_NegativeTest()
        {
            string currentUrl = webDriver.Url;

            bugReportPage.SelectCategory("sql");
            bugReportPage.SetSummary("       ");
            bugReportPage.SetDescription("Test_description");
            bugReportPage.setVisibility_private();
            bugReportPage.Submit();

            Assert.IsTrue(Warning.IsExist(webDriver));
        }

        [Test]
        public void T10_FillingDescriptionWithSpaces_NegativeTest()
        {
            string currentUrl = webDriver.Url;

            bugReportPage.SelectCategory("sql");
            bugReportPage.SetSummary("Test_task_" + RandomString.Create(20));
            bugReportPage.SetDescription("         ");
            bugReportPage.setVisibility_private();
            bugReportPage.Submit();

            Assert.IsTrue(Warning.IsExist(webDriver));
        }
        #endregion

        [TearDown]
        public void TearDown()
        {
            homePage.Logout();
            webDriver.Quit();
        }

    }
}