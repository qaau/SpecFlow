using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowProject.Models;
using SpecFlowProject.Tools;

namespace SpecFlowProject.Pages
{
    public class PracticeFormPage : BasePage
    {
        public PracticeFormPage(IWebDriver driver, Constants constants, Utils utils) : base(driver, constants, utils)
        {
        }
        
        public IWebElement firstNameInput => _driver.FindElement(By.CssSelector("#firstName"));
        
        public IWebElement lastNameInput => _driver.FindElement(By.CssSelector("#lastName"));
        
        public IWebElement emailInput => _driver.FindElement(By.CssSelector("#userEmail"));
        
        public IWebElement genderButton(string value) => _driver.FindElement(By.XPath($".//label[text()='{value}']"));
       
        public IWebElement mobileInput => _driver.FindElement(By.CssSelector("#userNumber"));
        
        public IWebElement dateOfBirthInput => _driver.FindElement(By.CssSelector("#dateOfBirthInput"));
        
        public IWebElement subjectsInput => _driver.FindElement(By.CssSelector("#subjectsInput"));
        
        public IWebElement hobbiesChecbox(string name) => _driver.FindElement(By.XPath($".//label[text()='{name}']/preceding-sibling::input"));
       
        public IWebElement uploadFileButton => _driver.FindElement(By.CssSelector("#uploadPicture"));
        
        public IWebElement currentAddressInput => _driver.FindElement(By.CssSelector("#currentAddress"));
        
        public IWebElement stateDropdown => _driver.FindElement(By.CssSelector("#state input"));
        
        public IWebElement cityDropdown => _driver.FindElement(By.CssSelector("#city input"));

        public void EnterDoB(string value)
        {
            Actions actions = new Actions(_driver);

            actions.Click(dateOfBirthInput)
                .KeyDown(Keys.Control)
                .SendKeys("a")
                .KeyUp(Keys.Control)
                .Build()
                .Perform();
            dateOfBirthInput.SendKeys(value);
        }
        
        public PracticeForm GetPracticeForm(string formName)
        {
            PracticeForm form = null;
            if (formName.ToLower().Contains("main"))
            {
                form = PracticeForm.CreateBuilder().Main().Build();
            }
            if (formName.ToLower().Contains("withsubjects"))
            {
                form = PracticeForm.CreateBuilder().Main().WithSubjects().Build();
            }
            if (formName.ToLower().Contains("withaddress"))
            {
                form = PracticeForm.CreateBuilder().Main().WithSubjects().WithAddress().Build();
            }

            return form;
        }
    }
}