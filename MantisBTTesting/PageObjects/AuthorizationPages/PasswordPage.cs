using OpenQA.Selenium;
using System.Threading;

namespace MantisBTTesting.PageObjects
{
    class PasswordPage
    {
        private IWebDriver driver;

        public PasswordPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement passwordInput 
            => driver.FindElement(By.XPath("//*[@id='password']"));
        IWebElement submitButton 
            => driver.FindElement(By.XPath("//*[@type='submit']"));

        public void SendPassword(string password)
        {
            passwordInput.SendKeys(password);
            Thread.Sleep(500);

            submitButton.Click();
        }
    }
}