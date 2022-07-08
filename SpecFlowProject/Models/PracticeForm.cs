using System.Collections.Generic;
using OpenQA.Selenium;
using SpecFlowProject.Models.Interfaces;

namespace SpecFlowProject.Models
{
    public class PracticeForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string DateOfBirth { get; set; }
        public string Subjects { get; set; }
        public string CurrentAddress { get; set; }
        
        public string State { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public List<string> Hobbies { get; set; }
        public string Pucture { get; set; }

        public static PracticeFormBuilder CreateBuilder()
        {
            return new PracticeFormBuilder();
        }
    }
}