using OpenQA.Selenium;

namespace MantisBTTesting.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl("https://www.mantisbt.org/bugs/my_view_page.php");
        }

        #region elements
        private IWebElement username        
            => driver.FindElement(By.XPath("//*[@class='user-info']"));
        private IWebElement logoutButton    
            => driver.FindElement(By.XPath("//*[@class='fa fa-sign-out ace-icon']"));
        private IWebElement NewTaskButton   
            => driver.FindElement(By.XPath("//*[@href='bug_report_page.php']"));
        #endregion

        #region methods

        public ProjectSelectPage GoToProjectSelectPage()
        {
            NewTaskButton.Click();
            return new ProjectSelectPage(driver);
        }

        public LoginPage GoToLoginPage()
        {
            username.Click();
            logoutButton.Click();

            return new LoginPage(driver);
        }    

        public string GetUsername()
        {
            return (username.Text);
        }    

        public void Logout()
        {
            username.Click();
            logoutButton.Click();
        }

        #endregion
    }
}