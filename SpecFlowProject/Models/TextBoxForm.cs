using SpecFlowProject.Models.Interfaces;

namespace SpecFlowProject.Models
{
    public class TextBoxForm
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }
        
        public static TextBoxFormBuilder CreateBuilder()
        {
            return new TextBoxFormBuilder();
        }
    }
}