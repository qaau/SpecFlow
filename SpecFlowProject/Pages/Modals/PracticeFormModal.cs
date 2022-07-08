using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject.Models;
using SpecFlowProject.Tools;

namespace SpecFlowProject.Pages
{
    public class PracticeFormModal : BasePage
    {
        public PracticeFormModal(IWebDriver driver, Constants constants, Utils utils) : base(driver, constants, utils)
        {
        }
        
        public string modalHeader => _driver.FindElement(By.ClassName("modal-title")).Text;
        
        public string studentName => _driver.FindElement(By.XPath(".//td[text() = 'Student Name']/following-sibling::td")).Text;
        
        public string studentEmail => _driver.FindElement(By.XPath(".//td[text()='Student Email']/following-sibling::td")).Text;
        public string gender => _driver.FindElement(By.XPath(".//td[text()='Gender']/following-sibling::td")).Text;
        public string mobile => _driver.FindElement(By.XPath(".//td[text()='Mobile']/following-sibling::td")).Text;
        public string dateOfBirth => _driver.FindElement(By.XPath(".//td[text()='Date of Birth']/following-sibling::td")).Text;
        public string subjects => _driver.FindElement(By.XPath(".//td[text()='Subjects']/following-sibling::td")).Text;
        public string hobbies => _driver.FindElement(By.XPath(".//td[text()='Hobbies']/following-sibling::td")).Text;
        public string picture => _driver.FindElement(By.XPath(".//td[text()='Picture']/following-sibling::td")).Text;
        public string address => _driver.FindElement(By.XPath(".//td[text()='Address']/following-sibling::td")).Text;
        public string stateAndCity => _driver.FindElement(By.XPath(".//td[text()='State and City']/following-sibling::td")).Text;


        public void ValidatePracticeFormModal(PracticeForm form)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(string.Concat(form.FirstName, " ", form.LastName), studentName, "Unexpected student name!");
                Assert.AreEqual(form.Gender?? String.Empty, gender, "Unexpected gender!");
                Assert.AreEqual(form.Mobile?? String.Empty, mobile, "Unexpected mobile!");
                Assert.AreEqual(form.DateOfBirth?? String.Empty, dateOfBirth.Replace(",", " "), "Unexpected DoB!");
                Assert.AreEqual(form.Subjects?? String.Empty, subjects, "Unexpected subject!");
                Assert.AreEqual(form.Hobbies?? new List<string>(), hobbies, "Unexpected hobbies!");
                Assert.AreEqual(form.Pucture?? String.Empty, picture, "Unexpected picture file name!");
                Assert.AreEqual(form.CurrentAddress?? String.Empty, address, "Unexpected address!");
                Assert.AreEqual(string.Concat(form.State?? string.Empty, form.City?? String.Empty), stateAndCity, "Unexpected state and city!");
            });
        }
    }
}