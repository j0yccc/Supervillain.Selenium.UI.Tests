using NUnit.Framework;
using Supervillain.Selenium.UI.Tests.Pages;
using Supervillain.Selenium.UI.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using static Supervillain.Selenium.UI.Tests.Pages.GamePage;

namespace Supervillain.Selenium.UI.Tests.Steps
{
    [Binding]
    public sealed class UserChallengeStepDefinition : FrameworkHooks
    {
        private readonly ScenarioContext _scenarioContext;
        LoginPage login = new LoginPage(driver);
        GamePage game = new GamePage(driver);
        ModalDialog dialog = new ModalDialog(driver);
        LeaderboardPage leaderboard = new LeaderboardPage(driver);
        String username = string.Empty;

        public UserChallengeStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"user is created")]
        public void GivenUserIsCreated()
        {
            username = Utils.RandomStrinGenerator(5);
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


        [Then(@"the score '(.*)' is displayed")]
        public void ThenTheScoreIsDisplayed(string score)
        {
            Assert.AreEqual(score, game.GetScore());
        }

        [When(@"the user check the final score")]
        public void WhenTheUserCheckTheFinalScore()
        {
            game.CheckScore();
        }

        [Then(@"the final score '(.*)' is displayed")]
        public void ThenTheFinalScoreIsDisplayed(string score)
        {
            Assert.AreEqual(score, leaderboard.GetFinalScore(username));
        }

        [When(@"the user choose the incorrect answer")]
        public void WhenTheUserChooseTheIncorrectAnswer()
        {
            game.SelectAnswerForBus(2);
        }

        [Then(@"the next challenge is displayed")]
        public void ThenTheNextChallengeIsDisplayed()
        {
            Assert.IsTrue(game.TryNextChallengeIsDisplayed());
        }

        [When(@"the challenge timeout")]
        public void WhenTheChallengeTimeout()
        {
            game.WaitforTimeout(10000);         
        }

        [Then(@"the covid poster is displayed")]
        public void ThenTheCovidPosterIsDisplayed()
        {
            Assert.IsTrue(game.CovidPosterIsDisplayed());
        }

        [Then(@"the try again option is displayed")]
        public void ThenTheTryAgainOptionIsDisplayed()
        {
            Assert.IsTrue(game.TryAgainIsDisplayed());
        }

    }
}
