using OpenQA.Selenium;
using SpecFlowProject.Pages;
using SpecFlowProject.Tools;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    public class BasicSteps
    {
        private readonly BasePage _basePage;
        private readonly Utils _utils;

        public BasicSteps(IWebDriver driver, Constants constants, Utils utils)
        {
            _utils = utils;
            _basePage = new BasePage(driver, constants, utils);
        }
        
        [Given(@"I navigate to '(.*)' page")]
        public void GivenINavigateToPage(string page)
        {
            _basePage.LoadPage(page);
        }

        [When(@"I click '(.*)' button")]
        public void WhenIClickButton(string buttonName)
        {
            _basePage.GetButtonByText(buttonName).Click();
        }
    }
}