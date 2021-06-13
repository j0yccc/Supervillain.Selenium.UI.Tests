using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Supervillain.Selenium.UI.Tests.Pages
{
    class LeaderboardPage : BaseClass
    {
        private By pagetitle = By.ClassName("option-label");
        private By tableRowsLocator = By.XPath("//tbody//tr");

        private IList<IWebElement> TableRows => Driver.FindElements(By.XPath("//tbody//tr"));

        public LeaderboardPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetFinalScore(string username)
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(tableRowsLocator));

            for (int i = 0; i < TableRows.Count; i++)
            {
  
                IWebElement row = Driver.FindElement(By.XPath("//tbody/tr[" + (i + 1) + "]"));
               
                if (row.Text.Contains(username))
                {
                    IWebElement scoreElement = Driver.FindElement(By.XPath("//tbody/tr[" + (i + 1) + "]//td[3]"));
                    return scoreElement.Text;
                }
            }

            return null;
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
                throw new Exception("Leaderboard page not load");
            }
        }
    }
}
