using System.Drawing.Printing;
using System.Linq;
using OpenQA.Selenium;
using SpecFlowProject.Models;
using SpecFlowProject.Pages;
using SpecFlowProject.Tools;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    public sealed class PracticeFormSteps
    {
        private readonly PracticeFormPage _practiceFormPage;
        private readonly PracticeFormModal _practiceFormModal;
        private readonly Utils _utils;
        
        public PracticeFormSteps(IWebDriver driver, Constants constants, Utils utils)
        {
            _utils = utils;
            _practiceFormPage = new PracticeFormPage(driver, constants, utils);
            _practiceFormModal = new PracticeFormModal(driver, constants, utils);
        }

        [When(@"I fill Practice form in with '(.*)' information")]
        public void WhenIFillPracticeFormInWithInformation(string formType)
        {
            PracticeForm form = _practiceFormPage.GetPracticeForm(formType);
            if(formType.ToLower().Contains("main"))
            {
                _practiceFormPage.firstNameInput.SendKeys(form.FirstName);
                _practiceFormPage.lastNameInput.SendKeys(form.LastName);
                _practiceFormPage.emailInput.SendKeys(form.Email);
                _practiceFormPage.genderButton(form.Gender).Click();
                _practiceFormPage.mobileInput.SendKeys(form.Mobile);
                _practiceFormPage.EnterDoB(form.DateOfBirth);
            }
            if (form.Hobbies != null)
            {
                form.Hobbies.ForEach(x=> _practiceFormPage.hobbiesChecbox(x).Click());
            }
        }

        [Then(@"I see '(.*)' Practice form output")]
        public void ThenISeePracticeFormOutput(string formType)
        {
            _practiceFormModal.ValidatePracticeFormModal(_practiceFormPage.GetPracticeForm(formType));
        }
    }
}