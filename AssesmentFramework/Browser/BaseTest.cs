using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SingletonFramework.Browser
{
    public class BaseTest : BaseDriver
    {

        /// <summary>
        /// Create driver and navigate to the webpage when execution of a test case starts
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            CreateDriver();
        }

        /// <summary>
        /// Take screenshots, delete user session and quit driver after the execution of a test case has finished
        /// </summary>
        [TearDown]
        public void CleanUp()
        {
            QuitDriver();
        }

    }
}
