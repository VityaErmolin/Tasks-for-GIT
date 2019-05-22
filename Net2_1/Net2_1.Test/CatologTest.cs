using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net2_1;

namespace Net2_1.Test
{
    [TestClass]
    class CatologTest
    {
        private Catalog _catalog;

        [TestInitialize]
        public void Initialize_Test()
        {
         _catalog = new Catalog { };
        }

        [TestMethod]
        public void AreEqualCTest()
        {
            Assert.AreEqual(_catalog.GetType(), typeof(Catalog));
        }

    }
}
