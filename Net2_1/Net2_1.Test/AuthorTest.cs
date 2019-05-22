using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net2_1;

namespace Net2_1.Test
{
    [TestClass]
    public class AuthorTest
    {
        
        [TestInitialize]
        public void Initialize_Test()
        {
            Author AlexanderPushkin = new Author("Alexander", "Pushkin");
        }

        [TestMethod]
        public void Equals_Test()
        {
            var LevTolstoy = new Author("Lev", "Tolstoy");
            var AlexanderPushkin = new Author("Alexander", "Pushkin");
            var Alexander = new Author("Alexander", "Pushkin");
            Assert.AreNotEqual(LevTolstoy, AlexanderPushkin);
            Assert.AreEqual(AlexanderPushkin, Alexander);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInitializeName()
        {
            var Alexander = new Author("Alexander", "PushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkinPushkin");
        }

    }
}
