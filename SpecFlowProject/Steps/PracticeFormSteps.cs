using OpenQA.Selenium;
using SpecFlowProject.Pages;
using SpecFlowProject.Tools;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    public sealed class PracticeFormSteps
    {
        private readonly PracticeFormPage _practiceFormPage;
        
        public PracticeFormSteps(IWebDriver driver, Constants constants, Utils utils)
        {
            _practiceFormPage = new PracticeFormPage();
        }

        
    }
}