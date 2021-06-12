using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supervillain.Selenium.UI.Tests.Pages
{
    public class LoginPage : BaseClass
    {
        //Locator
        private By usernameLocator = By.XPath("//input[@id='worrior_username']");
        private By createWorriorLocator = By.Id("warrior");
        private By startJourneyLocator = By.Id("start");
        
        //Page element
        private IWebElement usernameInput => Driver.FindElement(usernameLocator);
        private IWebElement createWarriorButton => Driver.FindElement(createWorriorLocator);
        private IWebElement startJourneyButton => Driver.FindElement(startJourneyLocator);
       
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void CreateWarrior(string username)
        {
            usernameInput.SendKeys(username);

            createWarriorButton.Click();

            StartJourney();
        }
      
        public void StartJourney()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(startJourneyLocator));

            startJourneyButton.Click();
        }

        protected override bool EvaluateLoadedStatus()
        {
            try
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(usernameLocator));
                return true;
            }
            catch
            {
                throw new Exception("Create warrior page not load");
            }    
        }
    }
}
