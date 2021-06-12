//using Microsoft.Extensions.Configuration;
//using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;

namespace Supervillain.Selenium.UI.Tests.Pages
{
    public class FrameworkHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public static IWebDriver driver { get; set; }

        [Binding]
        public class Initialize
        {
            private FeatureContext _featureContext;
            private string AppURL = "https://responsivefight.herokuapp.com/";

            public Initialize(FeatureContext featureContext)
            {
                _featureContext = featureContext;
            }

            [BeforeScenario]
            public void TestInitialize()
            {
                driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));                
                driver.Url = AppURL;
                driver.Manage().Window.Maximize();
            }
        }
        [Binding]
        public class CleanUp
        {
            [AfterScenario]
            public void CleanUpScenario()
            {
                driver.Quit();
            }
        }
    }
}