using OpenQA.Selenium;
using System.Collections.Generic;

namespace MantisBTTesting
{
    static class Warning
    {
        static public bool IsExist(IWebDriver driver)
        {
            List<IWebElement> elementList = new List<IWebElement>();
            elementList.AddRange(driver.FindElements(By.ClassName("alert-danger")));

            if (elementList.Count > 0)
            {
                return (true);
            }
            else return (false);
        }
    }

}
