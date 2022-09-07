using AssesmentFramework.Browser;
using OpenQA.Selenium;

namespace AssesmentFramework.PageObjects
{
    public class Pages:TestBase
    {
        public HomePage HomePageObject(IWebDriver Driver) { 
            var Page = new HomePage(Driver);
            return Page;
        }
        public PracticeForm PracticeFormObject(IWebDriver Driver)
        {
            var Page = new PracticeForm(Driver);
            return Page;
        }
    }
}
