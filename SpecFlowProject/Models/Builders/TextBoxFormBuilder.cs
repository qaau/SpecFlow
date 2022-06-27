namespace SpecFlowProject.Models.Interfaces
{
    public class TextBoxFormBuilder
    {
        private TextBoxForm _textBoxForm;
        
        public TextBoxFormBuilder()
        {
            _textBoxForm = new TextBoxForm();
        }

        public TextBoxFormBuilder Valid()
        {
            _textBoxForm.FullName = "John Dou";
            _textBoxForm.Email = "valid@email.com";
            _textBoxForm.CurrentAddress = "21 Main St. New York";
            _textBoxForm.PermanentAddress = "41 Arlington Ave, Washington, DC";

            return this;
        }
        
        public TextBoxFormBuilder WithInvalidEmail()
        {
            _textBoxForm.Email = "email.com";
            return this;
        }
        
        public TextBoxFormBuilder WithInvalidFullName()
        {
            _textBoxForm.FullName = "123";
            return this;
        }
        
        public TextBoxForm Build()
        {
            return _textBoxForm;
        }
    }
}