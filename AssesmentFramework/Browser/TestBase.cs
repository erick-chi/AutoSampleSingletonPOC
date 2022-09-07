using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace AssesmentFramework.Browser
{
    public class TestBase
    {
        protected IWebDriver driver;


        [SetUp]
        public void Setup() {
            driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Manage().Window.Maximize();
            GoToTestURL();
        }

        [TearDown]
        public void Cleanup() { 
            driver.Quit();
        }

        public void GoToTestURL() {
            driver.Navigate().GoToUrl(Common.Constants.URL);
            _ = new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(drv => drv.FindElement(By.CssSelector(Common.Selectors.HomePageBanner)));
        }

    }
}
