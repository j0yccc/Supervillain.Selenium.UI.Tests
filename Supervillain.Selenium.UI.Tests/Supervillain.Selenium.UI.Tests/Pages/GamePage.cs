using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supervillain.Selenium.UI.Tests.Pages
{
    public class GamePage : BaseClass
    {
        private By pagetitle = By.XPath("//p[@class='alpha-heading']");

        public GamePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetPageTitle()
        {
            return Driver.FindElement(pagetitle).Text;
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
