using AssesmentFramework.PageObjects;
using NUnit.Framework;

namespace AssesmentTests
{
    public class COETests:Pages
    {

        [TestCase]
        public void HomePageExistenceValidation()
        {
            Assert.IsTrue(HomePageObject(driver).IsHomePageDisplayed);
        }

        [TestCase]
        public void ValidatingElementsArePresentOnHomePage()
        {
            Assert.IsTrue(HomePageObject(driver).AreElements_Forms_Widgets_Present());
        }

        [TestCase]
        public void EnteredVSDisplayedDataValidation()
        {
            PracticeFormObject(driver).GotToPracticeFormPage();
            PracticeFormObject(driver).FillStudentsData();
            Assert.IsTrue(PracticeFormObject(driver).CompareEnteredDataVsDisplayedData());
        }
    }
}