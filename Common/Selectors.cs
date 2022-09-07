namespace Common
{
    public class Selectors
    {
        //Home Page Selectors
        public static readonly string HomePageBanner = "img.banner-image";
        public static readonly string CategoryCardsMenu = "//div[@class='category-cards']";
        public static string CategoryType(string type) => $"//h5[text() = '{type}']";

        //Practice Form Selectors
        public static readonly string PracticeFormButton = "//span[text()='Practice Form']/parent::li";
        public static readonly string StudentRegistrationForm = "form#userForm";
        public static readonly string FirstNameInput = "input#firstName";
        public static readonly string LastNameInput = "input#lastName";
        public static readonly string EmailInput = "input#userEmail";
        public static readonly string MobileInput = "input#userNumber";
        public static readonly string SubjectsInputXpath = "//div[contains(@class, 'subjects')]";
        public static readonly string HobbiesCheckboxesXpath = "//label[contains(@for, 'hobbies')]";
        public static readonly string GenderInputsXpath = "//label[contains(@for, 'gender')]";
        public static readonly string AddressInput = "textarea#currentAddress";
        public static readonly string SubmitButton = "button#submit";
        public static readonly string Table = "//table";
    }
}
