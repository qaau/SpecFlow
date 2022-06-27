using System;
using OpenQA.Selenium;
using SpecFlowProject.Models;
using SpecFlowProject.Tools;

namespace SpecFlowProject.Pages
{
    public class TextBoxPage : BasePage
    {
        public TextBoxPage(IWebDriver driver, Constants constants, Utils utils) : base(driver, constants, utils)
        {
        }
        
        public IWebElement fullName => _driver.FindElement(By.CssSelector("#userName-wrapper input"));
        
        public IWebElement email => _driver.FindElement(By.CssSelector("#userEmail-wrapper input"));
       
        public IWebElement currentAddress => _driver.FindElement(By.CssSelector("#currentAddress-wrapper textarea"));
       
        public IWebElement permanentAddress => _driver.FindElement(By.CssSelector("#permanentAddress-wrapper textarea"));
        
        public IWebElement outputFullName => _driver.FindElement(By.CssSelector("#output #name"));
        
        public IWebElement outputEmail => _driver.FindElement(By.CssSelector("#output #email"));

        public IWebElement outputCurrentAddress => _driver.FindElement(By.CssSelector("#output #currentAddress"));
        
        public IWebElement outputPermanentAddress => _driver.FindElement(By.CssSelector("#output #permanentAddress"));

        public TextBoxForm GetTextBoxForm(string formName)
        {
            switch (formName)
            {
                case "valid": 
                    return TextBoxForm.CreateBuilder().Valid().Build();
                default:
                    throw new ArgumentOutOfRangeException(formName,"Unknown TextBoxForm!");
            }
        }
    }
}