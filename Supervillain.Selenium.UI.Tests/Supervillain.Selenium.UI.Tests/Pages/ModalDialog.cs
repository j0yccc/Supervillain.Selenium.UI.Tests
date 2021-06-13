using OpenQA.Selenium;
using System;

namespace Supervillain.Selenium.UI.Tests.Pages
{
    public partial class GamePage
    {
        public class ModalDialog : BaseClass
        {
            //private IWebDriver driver;

            //Locator
            private By modalDialog = By.ClassName("modal-dialog");
            private By startLocator = By.XPath("//button[text()='Start']");
            private By tryAgainLocator = By.Id("close_modal_btn_2");
            private By tryNextLocator = By.Id("close_correct_modal_btn");
            private By scoreLocator = By.XPath("//p[@id='score']");

            //Element
            IWebElement StartButton => Driver.FindElement(startLocator);
            IWebElement TryAgainButton => Driver.FindElement(tryAgainLocator);
            IWebElement TryNextButton => Driver.FindElement(tryNextLocator);
            IWebElement Score => Driver.FindElement(scoreLocator);

            public ModalDialog(IWebDriver driver) : base(driver)
            {
                
            }

            public void Start()
            {
                StartButton.Click();
            }
            
            public void TryAgain()
            {
                TryAgainButton.Click();
            }

            public void TryNext()
            {
                TryNextButton.Click();
            }

            public string GetSccore()
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(scoreLocator));

                string text = Score.Text;
                string[] texts = text.Split(' ');
                string score = texts[4].Trim();

                return score;
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
