using System;

namespace Net1_1
{
    public class TextMaterial : Material 
    {
        private string _text;
        private const int _textLength = 10000;

        public string Text
        {
            get => _text;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > _textLength)
                {
                    throw new ArgumentException($"Length is more than {_textLength} or null");
                }
                _text = value;
            }
        }
        
        public TextMaterial(string text, string description =null) : base(description)
        {
            Description = description;
        }
        
        public override Material Clone()
        {
            return new TextMaterial(Text){Id=Id};
        }
    }
}