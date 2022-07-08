using System;
using System.Configuration;
using System.IO;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SpecFlowProject.Tools;
using TechTalk.SpecFlow;

namespace SpecFlowProject
{
    [Binding]
    public class Init
    {
        // Object Container used for DI in tests
        private readonly IObjectContainer _objectContainer;
        // Browser driver
        private IWebDriver _driver;
        // Constants used throughout the test classes
        private readonly Constants _constants;
        // Utility methods for tests
        private Utils _utils;

        private static string _projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

        private static string _driverPath = Path.Combine(_projectDirectory, "Drivers");

        public Init(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _constants = new Constants();
            _constants.MainUrl = ConfigurationManager.AppSettings.Get("main_url");
            _constants.Browser = ConfigurationManager.AppSettings.Get("browser");
            _constants.TimeOut = Int32.TryParse(ConfigurationManager.AppSettings.Get("timeOut"), out int result) ? result : 0;
            _constants.Headless = Boolean.TryParse(ConfigurationManager.AppSettings.Get("headless"), out bool isTrue) ? isTrue : false;
        }
        
        [BeforeScenario]
        public void BeforeScenario()
        {
            if (ConfigurationManager.AppSettings.Get("browser") == "Chrome")
            {
                ChromeOptions chromeOptions = new ();
                chromeOptions.AddArguments("disable-infobars");
                
                if (_constants.Headless)
                {
                    chromeOptions.AddArgument("headless");
                }
                
                chromeOptions.AddArgument("--window-size=1920,1080");
                chromeOptions.AddArgument("no-sandbox");
                chromeOptions.AddArguments("--disable-extensions");
                chromeOptions.AddArgument("--start-maximized");
                chromeOptions.AddArgument("Zoom 70%");
                _driver = new ChromeDriver(_driverPath, chromeOptions);
            }
            else if (ConfigurationManager.AppSettings.Get("browser") == "Firefox")
            {
                FirefoxOptions firefoxOptions = new();

                if (_constants.Headless)
                {
                    firefoxOptions.AddArgument("--headless");
                }

                firefoxOptions.AddArgument("--width=1920");
                firefoxOptions.AddArgument("--height=1080");
                firefoxOptions.AddArgument("--disable-extensions");
                firefoxOptions.AddAdditionalOption("acceptInsecureCerts", true);
                _driver = new FirefoxDriver(_driverPath);
            }

            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("main_url"));

            _utils = new Utils(_driver, _constants);
            
            // Register instances with DI container
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            _objectContainer.RegisterInstanceAs<Constants>(_constants);
            _objectContainer.RegisterInstanceAs<Utils>(_utils);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Close();
            _driver.Quit();
            _driver.Dispose();
        }
    }
}