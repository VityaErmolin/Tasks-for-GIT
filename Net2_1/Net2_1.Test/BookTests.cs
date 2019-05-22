using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net2_1;

namespace Net2_1.Test
{
    [TestClass]
    public class BookTests
    {
        private Book book;
        private int SizeTitle = 1000;

        [TestInitialize]
        public void Initialize_Test()
        {
            book = new Book("War and peace", "978-5-92-682585-2", new DateTime(1998, 07, 25));
        }

        [TestMethod]
        public void AreEqualBookTypeTest()
        {
            Assert.AreEqual(book.GetType(), typeof(Book));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void wTestInitializeTitle()
        {
           string s = new string('t', 1002);
           var idiot2 = new Book(null, "978-5-38-904730-3", new DateTime(1998, 07, 25));
        }

        [TestMethod]
        public void InitializeDateInBook_Test()
        {
            Assert.IsFalse(book.Date == null);
        }
        
        [TestMethod]
        public void TitleNotNullTest()
        {
            Assert.IsNotNull(book.Title);
        }

        [TestMethod]
        public void IsTrueTitleLengthTest()
        {
            Assert.IsTrue(book.Title.Length < SizeTitle);
        }
    }
}
