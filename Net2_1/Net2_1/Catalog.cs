using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Net2_1
{
    public class Catalog : IEnumerable<Book>
    {
        private readonly Dictionary<string, Book> _books;

        public Book this[string isbn]
        {
            get
            {
                CheckIsbn(ref isbn);
                return _books[isbn];
            }
        }

        public Catalog()
        {
            _books = new Dictionary<string, Book>();
        }

        public void Add(Book book)
        {
            var bookIsbn = book.Isbn;
            CheckIsbn(ref bookIsbn);
            _books.Add(bookIsbn, book);
        }

        private static void CheckIsbn(ref string isbn)
        {
            var r = new Regex(@"\d{3}-?\d{1}-?\d{2}-?\d{6}-?\d{1}");

            if (!r.IsMatch(isbn))
            {
                throw new ArgumentException("ISBN doesn't match pattern");
            }

            isbn = Regex.Replace(isbn, "-", "");
        }

        public IEnumerable<Book> GetBooksByAuthor(string firstName, string lastName)
        {
            var temp = new Author(firstName, lastName);
            return from book in _books
                from auth in book.Value
                where auth.Equals(temp)
                select book.Value;
        }

        public IEnumerable<Book> GetSortedBooksByDate()
        {
            return from book in _books.Values
                where book.Date != null
                orderby book.Date descending
                select book;
        }

        public IEnumerable<(Author, int)> GetAuthorAndCountBooks()
        {
            return from book in _books
                from auth in book.Value
                group auth by auth
                into tuple
                select (tuple.Key, tuple.Count());
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return _books.OrderBy(bookValue => bookValue.Value.Title).Select(book => book.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}