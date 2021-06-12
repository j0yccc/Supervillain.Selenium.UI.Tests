using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supervillain.Selenium.UI.Tests.Pages
{
    class Login : BaseClass
    {
        protected Login(IWebDriver driver) : base(driver)
        {

        }
      
        protected override bool EvaluateLoadedStatus()
        {
            throw new NotImplementedException();
        }
    }
}
