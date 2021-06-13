using NUnit.Framework;
using Supervillain.Selenium.UI.Tests.Pages;
using Supervillain.Selenium.UI.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using static Supervillain.Selenium.UI.Tests.Pages.GamePage;
//using Supervillain.Selenium.UI.Tests.Pages.GamePage;

namespace Supervillain.Selenium.UI.Tests.Steps
{
    [Binding]
    public sealed class UserChallengeStepDefinition : FrameworkHooks
    {
        private readonly ScenarioContext _scenarioContext;
        LoginPage login = new LoginPage(driver);
        GamePage game = new GamePage(driver);
        ModalDialog dialog = new ModalDialog(driver);

        public UserChallengeStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is created")]
        public void GivenUserIsCreated()
        {
            var username = Utils.RandomStrinGenerator(5);
            login.CreateWarrior(username);
        }

        [When(@"the user start the challenge '(.*)'")]
        public void WhenTheUserStartTheChallenge(string challengeName)
        {
            game.SelectChallenge(challengeName).Start();
        }

        [When(@"the user choose the correct answer")]
        public void WhenTheUserChooseTheCorrectAnswer()
        {
            game.SelectAnswerForBus(1);
        }

        [Then(@"the score is displayed")]
        public void ThenTheScoreIsDisplayed()
        {
            Assert.AreEqual("100", game.GetScore());
        }

        [When(@"the user choose the incorrect answer")]
        public void WhenTheUserChooseTheIncorrectAnswer()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the next challenge is displayed")]
        public void ThenTheNextChallengeIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the challenge timeout")]
        public void WhenTheChallengeTimeout()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the try again option is displayed")]
        public void ThenTheTryAgainOptionIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
