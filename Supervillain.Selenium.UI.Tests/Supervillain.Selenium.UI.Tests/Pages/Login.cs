using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supervillain.Selenium.UI.Tests.Pages
{
    class Login : BaseClass
    {
        //Locator
        private By usernameLocator = By.XPath("//input[@id='worrior_username']");
        private By createWorriorLocator = By.Id("warrior");
        
        //Page element
        private IWebElement usernameInput => Driver.FindElement(usernameLocator);
        private IWebElement createWarriorButton => Driver.FindElement(createWorriorLocator);

        protected Login(IWebDriver driver) : base(driver)
        {
        }

        public void LoginWithUsername(string username)
        {
            usernameInput.SendKeys(username);

            createWarriorButton.Click();
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
