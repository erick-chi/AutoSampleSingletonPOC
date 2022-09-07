using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SingletonFramework.Browser
{
    public class BasePage<TypeOfPage> : BaseDriver where TypeOfPage : new()
    {
        private static TypeOfPage page;
        /// <summary>
        /// Holds the new created instance of the page
        /// </summary>
        public static TypeOfPage Page
        {
            get
            {
                if (page == null)
                {
                    page = new TypeOfPage();

                }
                return page;
            }
        }

    }
}
