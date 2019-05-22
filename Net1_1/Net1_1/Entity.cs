using System;

namespace Net1_1
{
    public abstract class Entity
    {
        private readonly int _descriptionLenght = 256;
        private string _description;

        public Guid Id { get; set; }

        public string Description
        {
            get => _description;
            set
            {
                if (value != null && value.Length > _descriptionLenght )
                {
                    throw new ArgumentException($"Description can't be more than {_descriptionLenght} characters");
                }
                _description = value;
            }
        }

        public Entity(string description=null)
        {
            Description = description;
            this.GenerationId();
        }
       
        public override string ToString()
        {
            return Description;
        }

        public override bool Equals(object obj)
        {
            return (obj is Entity temp && Id == temp.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}