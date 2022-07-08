using System.Collections.Generic;
using System.Text;
using SpecFlowProject.Pages;

namespace SpecFlowProject.Models.Interfaces
{
    public class PracticeFormBuilder
    {
        private PracticeForm _practiceForm;
        private PracticeFormPage _practiceFormPage;
        
        public PracticeFormBuilder()
        {
            _practiceForm = new PracticeForm();
        }

        public PracticeFormBuilder Main()
        {
            _practiceForm.FirstName = "John";
            _practiceForm.LastName = "Dou";
            _practiceForm.Email = "valid@email.com";
            _practiceForm.Gender = "Male";
            _practiceForm.Mobile = "1231231233";
            _practiceForm.DateOfBirth = "28 May 1980";
                
            return this;
        }
        
        public PracticeFormBuilder WithSubjects()
        {
            _practiceForm.Subjects = "Math, Literature";
            return this;
        }
        
        public PracticeFormBuilder WithAddress()
        {
            _practiceForm.Subjects = "23, Main Str., Los Angeles";
            return this;
        }
        
        public PracticeFormBuilder WithHobbies()
        {
            _practiceForm.Hobbies = new List<string> {"Sports", "Music"};
            return this;
        }
        public PracticeForm Build()
        {
            return _practiceForm;
        }
    }
}