using OpenQA.Selenium;

namespace MantisBTTesting.PageObjects
{
    class BugReportPage
    {
        private IWebDriver driver;

        public BugReportPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region elements

        IWebElement submitButton => driver.FindElement(By.XPath("//*[@type='submit']"));
        IWebElement categoryDropdown => driver.FindElement(By.XPath("//*[@id='category_id']"));
        IWebElement summaryInput => driver.FindElement(By.XPath("//*[@id='summary']"));
        IWebElement descriptionInput => driver.FindElement(By.XPath("//*[@id='description']")); 
        IWebElement visibilityRadio => driver.FindElement(By.XPath("//*[text()='приватная']"));

        #endregion

        #region methods

        public void Submit()
        {
            submitButton.Click();
        }

        public void SelectCategory(string category)
        {
            categoryDropdown.Click();
            categoryDropdown.FindElement(By.XPath("//*[text()='"+category+"']")).Click();
            categoryDropdown.SendKeys(Keys.Escape);
        }

        public void SetDescription(string text)
        {
            descriptionInput.SendKeys(text);
        }

        public void setVisibility_private()
        {
            visibilityRadio.Click();
        }

        public void SetSummary(string text)
        {
            summaryInput.SendKeys(text);
        }

        public int SummaryLength()
        {
            int length = summaryInput.GetAttribute("Value").Length;

            return (length);
        }

        #endregion
    }
}
