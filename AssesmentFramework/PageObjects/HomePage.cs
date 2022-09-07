using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SingletonFramework.Browser;

namespace SingletonFramework.PageObjects
{
    public class HomePage : BasePage<HomePage>
    {
        //public HomePage(IWebDriver driver)
        //{
        //    this.driver = driver;           
        //}
        public bool AreElements_Forms_Widgets_Present() { 
            return IsCategoryTypeDisplayed(Common.Constants.CATEGORY_FORMS)
                && IsCategoryTypeDisplayed(Common.Constants.CATEGORY_ELEMENTS)
                && IsCategoryTypeDisplayed(Common.Constants.CATEGORY_WIDGETS);
        }
        private bool IsCategoryTypeDisplayed(string CategoryType) {
            var CategoryElement = CategoryCardsMenu.FindElement(By.XPath(Convert.ToChar(46) + Common.Selectors.CategoryType(CategoryType)));
            return CategoryElement.Displayed;
        }

        public bool IsHomePageDisplayed => HomePageBanner.Displayed;
        IWebElement HomePageBanner => driver.FindElement(By.CssSelector(Common.Selectors.HomePageBanner));
        IWebElement CategoryCardsMenu => new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(drv => drv.FindElement(By.XPath(Common.Selectors.CategoryCardsMenu)));
    }
}
