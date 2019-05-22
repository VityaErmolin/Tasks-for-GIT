using System;
using Net1_1.Enums;

namespace Net1_1
{
    public class Reference : Material
    {
        private string _content;
        public ReferenceType TypeReference { get; set; }

        public string Content
        {
            get => _content;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Reference can't be empty");
                }
                _content = value;
            }
        }

        public Reference(string content, ReferenceType typeReference, string description =null) : base(description)
        {
            Content = content;
            TypeReference = typeReference;
            Description = description;
        }

        public override Material Clone()
        {
            return new Reference(Content, TypeReference) {Id = Id};
        }
    }
}
