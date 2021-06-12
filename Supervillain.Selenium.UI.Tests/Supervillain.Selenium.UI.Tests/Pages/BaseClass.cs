using OpenQA.Selenium; 
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Supervillain.Selenium.UI.Tests.Pages
{
    public abstract class BaseClass : LoadableComponent<BaseClass>
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;
        protected const int DefaultTimeout = 15;

        protected BaseClass(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, new TimeSpan(0, 0, DefaultTimeout));
        }

        public IWebDriver Driver
        {
            get { return _driver; }
        }

        public WebDriverWait Wait
        {
            get { return _wait; }
        }

        public void RefreshPage()
        {
            _driver.Navigate().Refresh();
        }

        protected override void ExecuteLoad()
        {
        }
    }
}



