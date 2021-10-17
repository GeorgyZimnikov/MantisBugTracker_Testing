using OpenQA.Selenium;

namespace MantisBTTesting.PageObjects
{
    class ProjectSelectPage
    {
        private IWebDriver driver;
        public ProjectSelectPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement submitButton => driver.FindElement(By.XPath("//*[@type='submit']"));

        public BugReportPage Submit()
        {
            submitButton.Click();
            return new BugReportPage(driver);
        }
    }
}
