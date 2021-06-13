using OpenQA.Selenium;
using System;

namespace Supervillain.Selenium.UI.Tests.Pages
{
    public partial class GamePage
    {
        public class ModalDialog : BaseClass
        {
            //Locator
            private By modalDialog = By.ClassName("modal-dialog");
            private By startLocator = By.XPath("//button[text()='Start']");
            private By tryAgainLocator = By.XPath("//button[text()='Try again']");
            private By tryNextChallengeLocator = By.XPath("//button[text()='Try the next battle']");
            private By scoreLocator = By.XPath("//p[@id='score']");
            private By checkScoreLocator = By.Id("leaderboard_link");
            private By covidPosterLocator = By.Id("img-protection_poster");

            //Element
            IWebElement StartButton => Driver.FindElement(startLocator);
            IWebElement TryAgainButton => Driver.FindElement(tryAgainLocator);
            IWebElement TryNexChallengetButton => Driver.FindElement(tryNextChallengeLocator);
            IWebElement Score => Driver.FindElement(scoreLocator);
            IWebElement CheckScoreButton => Driver.FindElement(checkScoreLocator);
            IWebElement covidPoster => Driver.FindElement(covidPosterLocator);

            public ModalDialog(IWebDriver driver) : base(driver)
            {
                
            }

            internal void Start()
            {
                StartButton.Click();
            }
            
            internal void TryAgain()
            {
                TryAgainButton.Click();
            }

            internal void TryNext()
            {
                TryAgainButton.Click();
            }

            internal string GetSccore()
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(scoreLocator));

                string text = Score.Text;
                string[] texts = text.Split(' ');
                string score = texts[4].Trim();

                return score;
            }

            internal bool? TryAgainIsDisplayed()
            {
                try
                {
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(tryAgainLocator));

                }
                catch (Exception e)
                {
                    return TryAgainButton.Displayed;
                }
                return null;
            }

            internal bool? NextChallengeIsDisplayed()
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(tryNextChallengeLocator));


                return TryNexChallengetButton.Displayed;
            }

            internal bool? CovidPosterIsDisplayed()
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(covidPosterLocator));


                return covidPoster.Displayed;
            }

            internal void CheckScore()
            {
                CheckScoreButton.Click();
            }

            protected override bool EvaluateLoadedStatus()
            {
                try
                {
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(modalDialog));
                    return true;
                }
                catch
                {
                    throw new Exception("Modal Dialog not load");
                }
            }
        }
    }
}
