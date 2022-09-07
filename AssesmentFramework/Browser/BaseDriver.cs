using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SingletonFramework.Browser
{
    public class BaseDriver
    {
        protected static IWebDriver driver = null;


        public void CreateDriver() {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Manage().Window.Maximize();
            GoToTestURL();
        }

        public void QuitDriver() {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

        public void GoToTestURL() {
            driver.Navigate().GoToUrl(Common.Constants.URL);
            _ = new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(drv => drv.FindElement(By.CssSelector(Common.Selectors.HomePageBanner)));
        }

    }
}
