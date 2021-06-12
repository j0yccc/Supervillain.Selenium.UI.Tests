using NUnit.Framework;
using OpenQA.Selenium;
using Supervillain.Selenium.UI.Tests.Pages;
using TechTalk.SpecFlow;

namespace Supervillain.Selenium.UI.Tests.Steps
{
    [Binding]
    public sealed class CreateUserStepDefinitions : FrameworkHooks
    {

        private readonly ScenarioContext _scenarioContext;
        LoginPage login = new LoginPage(driver);
        GamePage game = new GamePage(driver);

        public CreateUserStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the page is loaded")]
        public void GivenThePageIsoaded()
        {
          
        }

        [When(@"user create warrior '(.*)'")]
        public void WhenUserCreateWarrior(string username)
        {
            login.CreateWarrior(username);
        }

        [Then(@"the user is created")]
        public void ThenTheUserIsCreated()
        {
           //Assert username on page
        }

        [Then(@"the game page is displayed")]
        public void ThenTheGamePageIsDisplayed()
        {
            Assert.AreEqual("COVID-19 THE GAME", game.GetPageTitle());
        }

    }
}
