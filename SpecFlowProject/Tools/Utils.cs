using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace SpecFlowProject.Tools
{
    [Binding]
    public class Utils
    {
        private readonly IWebDriver _driver;
        protected Constants _constants;

        public Utils(IWebDriver driver, Constants constants)
        {
            _driver = driver;
            _constants = constants;
        }
        
        public void WaitElementDisplayed(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_constants.TimeOut));
            wait.Until(ElementIsDisplayed(element));
        }
        
        public void WaitElementClickable(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_constants.TimeOut));
            wait.Until(ElementIsClickable(element));
        }

        #region WaitConditions
        public static Func<IWebDriver, IWebElement> ElementIsDisplayed(IWebElement element) {
            return (driver) => {
                try {
                    return element.Displayed ? element : null;
                } catch (StaleElementReferenceException){
                    return null;
                }
            };
        }
        
        public static Func<IWebDriver, IWebElement> ElementIsClickable(IWebElement element) {
            return (driver) => {
                try {
                    return element.Displayed && element.Enabled  ? element : null;
                } catch (StaleElementReferenceException){
                    return null;
                }
            };
        }
        #endregion

        public void ScrollToElement(IWebElement element)
        {
            new Actions(_driver).MoveToElement(element).Perform();
        }
    }
}