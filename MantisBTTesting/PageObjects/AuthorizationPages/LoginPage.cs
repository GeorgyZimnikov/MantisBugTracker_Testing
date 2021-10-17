using OpenQA.Selenium;

namespace MantisBTTesting.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region elements

        IWebElement usernameInput 
            => driver.FindElement(By.XPath("//*[@id='username']"));
        IWebElement submitButton 
            => driver.FindElement(By.XPath("//*[@type='submit']"));
        IWebElement anonButton 
            => driver.FindElement(By.XPath("//*[@class='back-to-login-link pull-right']"));

        #endregion

        public PasswordPage SendUsername(string username)
        {
            usernameInput.SendKeys(username);
            submitButton.Click();

            return new PasswordPage(driver);
        }

        public void LoginAnon()
        {
            anonButton.Click();
        }
    }
}