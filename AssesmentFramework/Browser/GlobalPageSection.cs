using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SingletonFramework.Browser
{
    public abstract class GlobalPageSection<TypeOfSection> : BaseDriver where TypeOfSection : new()
    {
        //private data members
        private static TypeOfSection section;
        //using properties
        public static TypeOfSection Section
        {
            get
            {
                if (section == null)
                {
                    section = new TypeOfSection();
                }
                return section;
            }
        }
    }
}
