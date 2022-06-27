using System;
using OpenQA.Selenium;
using SpecFlowProject.Tools;

namespace SpecFlowProject.Pages
{
    public class BasePage
    {
        public IWebDriver _driver;
        protected Constants _constants;
        protected  Utils _utils;

        public BasePage(IWebDriver driver, Constants constants, Utils utils)
        {
            _driver = driver;
            _constants = constants;
            _utils = utils;
        }
        
        public IWebElement section(string sectionName) => _driver.FindElement(By.XPath($".//h5[text()='{sectionName}']"));
        
        public IWebElement item(string itemName) => _driver.FindElement(By.XPath($".//span[text() = '{itemName}']"));

        public IWebElement header(string headerText) => _driver.FindElement(By.XPath($".//div[text()='{headerText}']"));

        public IWebElement GetButtonByText(string name)
        {
            return _driver.FindElement(By.XPath($".//button[text() = '{name}']"));
        }
        
        public void LoadSection(string item)
        {
            if (_driver.Url != _constants.MainUrl)
            {
                _driver.Navigate().GoToUrl(_constants.MainUrl);
            }
            var sectionName = GetSection(item);
            _utils.WaitElementDisplayed(section(sectionName));
            _utils.ScrollToElement(section(sectionName));
            section(sectionName).Click();
        }
        
        public void LoadPage(string itemName)
        {
            LoadSection(itemName);
            _utils.WaitElementClickable(item(itemName));
            item(itemName).Click();
            _utils.WaitElementDisplayed(header(itemName));
        }

        private string GetSection(string item)
        {
            switch (item)
            {
                case "Text Box":
                case "Check Box":
                case "Radio Button":
                    return "Elements";
                case "Practice Form":
                    return "Forms";
                default:
                    throw new ArgumentException("Not implemented!");
            }
        }
    }
}