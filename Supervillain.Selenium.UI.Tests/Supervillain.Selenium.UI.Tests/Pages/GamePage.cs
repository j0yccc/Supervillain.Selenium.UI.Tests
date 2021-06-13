using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Supervillain.Selenium.UI.Tests.Pages
{
    public partial class GamePage : BaseClass
    {
        //Locator
        private By pagetitle = By.XPath("//p[@class='alpha-heading']");
        private By userNameLocator = By.Id("welcome_text"); 

        //Element
        IWebElement usernameField => Driver.FindElement(userNameLocator);

        public GamePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetPageTitle()
        {
            return Driver.FindElement(pagetitle).Text;
        }

        public string GetUserName()
        {
            string text = usernameField.Text;
            string[] texts = text.Split(' ');

            return texts[texts.Length - 1];
        }

        public ModalDialog SelectChallenge(string challengeName)
        {
            IWebElement challenge = Driver.FindElement(By.XPath("//a[normalize-space()='" +challengeName+ "']"));

            challenge.Click();

            return new ModalDialog(Driver);
        }

        internal void SelectAnswerForBus(int answerNumber)
        {
            IWebElement answer = Driver.FindElement(By.Id("bus_answer_" + answerNumber));
          
            answer.Click();
        }

        internal string GetScore()
        {
            var dialog = new ModalDialog(Driver);
            var score = dialog.GetSccore();
            return score;
        }

        internal void CheckScore()
        {
            var dialog = new ModalDialog(Driver);
            dialog.CheckScore();
        }

        public bool? TryAgainIsDisplayed()
        {
            var dialog = new ModalDialog(Driver);
            return dialog.TryAgainIsDisplayed();
        }

        internal bool? TryNextChallengeIsDisplayed()
        {
            var dialog = new ModalDialog(Driver);
            return dialog.NextChallengeIsDisplayed();
        }

        internal void WaitforTimeout(int timeout)
        {
            Thread.Sleep(timeout);
        }

        internal bool? CovidPosterIsDisplayed()
        {
            var dialog = new ModalDialog(Driver);
            return dialog.CovidPosterIsDisplayed();
        }

        protected override bool EvaluateLoadedStatus()
        {
            try
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(pagetitle));
                return true;
            }
            catch
            {
                throw new Exception("Game page not load");
            }
        }
    }
}
