using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Net2_1
{
    public class Book : IEnumerable<Author>
    {
        private string _title;
        private string _isbn;
        private const int SizeTitle = 1000;
        private readonly List<Author> _authors;

        public string Title
        {
            get => _title;
            set
            {
                if (value == null || value.Length > SizeTitle)
                {
                    throw new ArgumentException($"The book title can't be empty and more than {SizeTitle} characters");
                }

                _title = value;
            }
        }

        public string Isbn
        {
            get => _isbn;
            set
            {
                CheckIsbn(ref value);
                _isbn = value;
            }
        }

        public DateTime? Date { get; }

        public Book(string title, string isbn, params Author[] authors)
        {
            Title = title;
            Isbn = isbn;

            if (authors != null)
            {
                _authors = new List<Author>(authors);
            }
        }

        public Book(string title, string isbn, DateTime date, params Author[] authors) : this(title, isbn, authors)
        {
            Date = date;
        }

        private static void CheckIsbn(ref string isbn)
        {
            var r = new Regex(@"\d{3}-?\d{1}-?\d{2}-?\d{6}-?\d{1}");

            if (!r.IsMatch(isbn))
            {
                throw new ArgumentException("ISBN doesn't match pattern");
            }

            isbn = isbn.Replace("-", "");
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Title: {Title}");
            result.AppendLine($"ISBN: {ShowIsbn()}");
            result.Append("Author: ");

            foreach (var a in _authors)
            {
                result.Append(a);
            }

            result.AppendLine();

            if (Date != null)
            {
                result.AppendLine($"Date: {Date:dd-MM-yyyy}");
            }

            return result.ToString();
        }

        private string ShowIsbn()
        {
            return Isbn.Substring(0, 3) + "-"
                                        + Isbn.Substring(3, 1) + "-"
                                        + Isbn.Substring(4, 2) + "-"
                                        + Isbn.Substring(6, 6) + "-"
                                        + Isbn.Substring(12, 1);
        }

        public override bool Equals(object obj)
        {
            return obj is Book temp && temp.Isbn == Isbn;
        }

        public override int GetHashCode()
        {
            return Isbn.GetHashCode();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Author> GetEnumerator()
        {
            return _authors.GetEnumerator();
        }
    }
}