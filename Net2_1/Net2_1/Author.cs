using System;

namespace Net2_1
{
    public class Author
    {
        private string _firstName;
        private string _lastName;
        private const int SizeName = 200;

        public string FirstName
        {
            get => _firstName;
            set
            {
                CheckName(value);
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                CheckName(value);
                _lastName = value;
            }
        }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        private static void CheckName(string str)
        {
            if (str == null || str.Length > SizeName)
            {
                throw new ArgumentException($"The length than {SizeName} characters or null");
            }
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " ";
        }

        public override bool Equals(object obj)
        {
            return obj is Author temp &&
                   string.Equals(FirstName, temp.FirstName, StringComparison.CurrentCultureIgnoreCase) &&
                   string.Equals(LastName, temp.LastName, StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).ToLower().GetHashCode();
        }
    }
}