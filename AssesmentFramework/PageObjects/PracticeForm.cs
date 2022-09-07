using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AssesmentFramework.PageObjects
{
    public class PracticeForm:Pages
    {
        public PracticeForm(IWebDriver driver)
        {
            this.driver = driver;           
        }
        private void ClickCategoryType(string CategoryType) {
            var CategoryElement = CategoryCardsMenu.FindElement(By.XPath(Convert.ToChar(46) + Common.Selectors.CategoryType(CategoryType)));
            CategoryElement.Click();
        }
        private void ClickPracticeFormButton() => PracticeFormButton.Click();

        public void GotToPracticeFormPage() {
            ClickCategoryType(Common.Constants.CATEGORY_FORMS);
            ClickPracticeFormButton();
        }
        public string SelectGenderByIndex(int index) {
            var GenderElement = GenderChecks[index];
            var Text = GenderElement.Text;
            GenderElement.Click();
            return Text;
        }
        public string SelectStudentHobby(int index) {
            var HobbyElement = HobbiesChecks[index];
            var StudentHobby = HobbyElement.Text;
            HobbyElement.Click();
            return StudentHobby;
        }
        public void FillStudentsData() {
            Mapping.StudentMapping.FirstName = Faker.Name.First();
            FirstNameInput.SendKeys(Mapping.StudentMapping.FirstName);
            Mapping.StudentMapping.LastName = Faker.Name.Last();   
            LastNameInput.SendKeys(Mapping.StudentMapping.LastName);
            Mapping.StudentMapping.Email = Common.Constants.USER_TESTMAIL;
            EmailInput.SendKeys(Mapping.StudentMapping.Email);
            Mapping.StudentMapping.StudentGender = SelectGenderByIndex(0);
            Mapping.StudentMapping.PhoneNumber = Common.Constants.USER_TESTPHONE;
            PhoneNumberInput.SendKeys(Mapping.StudentMapping.PhoneNumber);
            Mapping.StudentMapping.StudentHobby = SelectStudentHobby(0);
            Mapping.StudentMapping.CurrentAddressData = Faker.Address.StreetAddress();
            CurrentAddress.SendKeys(Mapping.StudentMapping.CurrentAddressData);
            ClickSubmitButton();
        }
        public List<List<string>> GetTableData()
        {
            List<List<string>> tableElementsList = new ();
            var tableRows = Table.FindElements(By.XPath(".//tbody/tr"));
            foreach (var tableRow in tableRows)
            {
                var rowCells = tableRow.FindElements(By.XPath(".//td"));

                var stringElements = new List<string>();

                foreach (var Element in rowCells)
                {
                    stringElements.Add(Element.Text);
                };

                {
                    tableElementsList.Add(stringElements);
                };
            }
            return tableElementsList;
        }

        public void ClickSubmitButton() {
            try
            {
                SubmitButton.Click();
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                _= (string)js.ExecuteScript("document.getElementById(\"submit\").click()");
                Console.WriteLine("Clicked Using JS");
            }
        }

        public bool CompareEnteredDataVsDisplayedData() {
            var TableData = GetTableData();
            var HashMappedData = TableData.ToDictionary(keySelector: ele => ele[0], elementSelector: ele => ele[1]);

            var FirstNameValidation = HashMappedData.Where(item => item.Key.Equals(Common.Constants.STUDENT_NAME)).Select(item => item.Value).FirstOrDefault().Contains(Mapping.StudentMapping.FirstName);
            var LastNameValidation = HashMappedData.Where(item => item.Key.Equals(Common.Constants.STUDENT_NAME)).Select(item => item.Value).FirstOrDefault().Contains(Mapping.StudentMapping.LastName);
            var StudentGenderValidation = HashMappedData.Where(item => item.Key.Equals(Common.Constants.STUDENT_GENDER)).Select(item => item.Value).FirstOrDefault().Contains(Mapping.StudentMapping.StudentGender);
            var EmailValidation = HashMappedData.Where(item => item.Key.Equals(Common.Constants.STUDENT_EMAIL)).Select(item => item.Value).FirstOrDefault().Contains(Mapping.StudentMapping.Email);
            var PhoneNumberValidation = HashMappedData.Where(item => item.Key.Equals(Common.Constants.STUDENT_PHONE)).Select(item => item.Value).FirstOrDefault().Contains(Mapping.StudentMapping.PhoneNumber);
            var StudentHobbyValidation = HashMappedData.Where(item => item.Key.Equals(Common.Constants.STUDENT_HOBBY)).Select(item => item.Value).FirstOrDefault().Contains(Mapping.StudentMapping.StudentHobby);
            var CurrentAddressValidation = HashMappedData.Where(item => item.Key.Equals(Common.Constants.STUDENT_ADDRESS)).Select(item => item.Value).FirstOrDefault().Contains(Mapping.StudentMapping.CurrentAddressData);

            return FirstNameValidation
                && LastNameValidation
                && StudentGenderValidation
                && EmailValidation
                && PhoneNumberValidation
                && StudentHobbyValidation
                && CurrentAddressValidation;
        }

        IWebElement CategoryCardsMenu => new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(drv => drv.FindElement(By.XPath(Common.Selectors.CategoryCardsMenu)));
        IWebElement PracticeFormButton=> new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(drv => drv.FindElement(By.XPath(Common.Selectors.PracticeFormButton)));
        IWebElement FirstNameInput => new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(drv => drv.FindElement(By.CssSelector(Common.Selectors.FirstNameInput)));
        IWebElement LastNameInput => driver.FindElement(By.CssSelector(Common.Selectors.LastNameInput));
        IWebElement EmailInput => driver.FindElement(By.CssSelector(Common.Selectors.EmailInput));
        IList<IWebElement> GenderChecks => driver.FindElements(By.XPath(Common.Selectors.GenderInputsXpath));
        IWebElement PhoneNumberInput => driver.FindElement(By.CssSelector(Common.Selectors.MobileInput));
        IList<IWebElement> HobbiesChecks => driver.FindElements(By.XPath(Common.Selectors.HobbiesCheckboxesXpath));
        IWebElement CurrentAddress => driver.FindElement(By.CssSelector(Common.Selectors.AddressInput));
        IWebElement SubmitButton => driver.FindElement(By.CssSelector(Common.Selectors.SubmitButton));
        IWebElement Table => new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(drv => drv.FindElement(By.XPath(Common.Selectors.Table)));
    }
}
