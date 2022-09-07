using SingletonFramework.PageObjects;
using NUnit.Framework;
using SingletonFramework.Browser;

namespace SingletonTests
{
    public class COETests:BaseTest
    {

        [TestCase]
        public void HomePageExistenceValidation()
        {
            Assert.IsTrue(HomePage.Page.IsHomePageDisplayed);
        }

        [TestCase]
        public void ValidatingElementsArePresentOnHomePage()
        {
            Assert.IsTrue(HomePage.Page.AreElements_Forms_Widgets_Present());
        }

        [TestCase]
        public void EnteredVSDisplayedDataValidation()
        {
            PracticeForm.Page.GotToPracticeFormPage();
            PracticeForm.Page.FillStudentsData();
            Assert.IsTrue(PracticeForm.Page.CompareEnteredDataVsDisplayedData());
        }
    }
}