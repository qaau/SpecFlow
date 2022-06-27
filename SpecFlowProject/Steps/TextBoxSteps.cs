using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject.Models;
using SpecFlowProject.Pages;
using SpecFlowProject.Tools;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject.Steps
{
    [Binding]
    public sealed class TextBoxSteps
    {
        private readonly TextBoxPage _textBoxPage;
        private readonly Utils _utils;

        public TextBoxSteps(IWebDriver driver, Constants constants, Utils utils)
        {
            _utils = utils;
            _textBoxPage = new TextBoxPage(driver, constants, utils);
        }

        [When(@"I fill the form in with '(.*)' information")]
        public void WhenIFillTheFormInWithInformation(string formType)
        {
            TextBoxForm form = _textBoxPage.GetTextBoxForm(formType);
            _textBoxPage.fullName.SendKeys(form.FullName);
            _textBoxPage.email.SendKeys(form.Email);
            _textBoxPage.currentAddress.SendKeys(form.CurrentAddress);
            _textBoxPage.permanentAddress.SendKeys(form.PermanentAddress);
        }

        [Then(@"I see '(.*)' Text Box form output")]
        public void ThenISeeTextBoxFormOutput(string formType)
        {
            TextBoxForm form = _textBoxPage.GetTextBoxForm(formType);
            _utils.WaitElementDisplayed(_textBoxPage.outputPermanentAddress);
            _utils.ScrollToElement(_textBoxPage.outputPermanentAddress);
            Assert.Multiple(() =>
            {
                StringAssert.Contains(form.FullName, _textBoxPage.outputFullName.Text, "Unexpected output FullName");
                StringAssert.Contains(form.Email, _textBoxPage.outputEmail.Text, "Unexpected output Email");
                StringAssert.Contains(form.CurrentAddress, _textBoxPage.outputCurrentAddress.Text, "Unexpected output CurrentAddress");
                StringAssert.Contains(form.PermanentAddress, _textBoxPage.outputPermanentAddress.Text, "Unexpected output PermanentAddress");

            });
        }
    }
}