using SingletonFramework.Browser;
using SingletonFramework.PageObjects;
using SpecflowTests.Drivers;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTests.StepDefinitions
{
    [Binding]
    public class DemoTestsStepDefinitions:Setups
    {
        [Given(@"User Goes To Base URL")]
        public void GivenUserGoesToBaseURL()
        {
            GoToTestURL();
        }

        [Then(@"Validate Home Page Is Displayed")]
        public void ThenValidateHomePageIsDisplayed()
        {
            HomePage.Page.IsHomePageDisplayed.Should().BeTrue();
        }
    }
}
