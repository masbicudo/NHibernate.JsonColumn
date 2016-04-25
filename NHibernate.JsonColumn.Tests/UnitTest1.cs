using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.JsonColumn.Tests.Models;

namespace NHibernate.JsonColumn.Tests
{
    [TestClass]
    public class UnitTest1 : UnitTestBase
    {
        [TestMethod]
        public void TestMethod_SavePropertyAsJson()
        {
            var obj = new Root
            {
                Animal = new Lion(52f, 260f, 1200f),
            };

            this.Session.Save(obj);
        }

        [TestMethod]
        public void TestMethod_LoadPropertyWithJson()
        {
            // SETUP - first we need to save to the database
            var obj = new Root
            {
                Animal = new Lion(45f, 210f, 1560f),
            };

            using (var session = this.SessionProvider.SessionFactory.OpenSession())
                session.Save(obj);

            // TEST - load the previously saved entity
            var obj2 = this.Session.Get<Root>(obj.Id);

            // ASSERT
            Assert.IsInstanceOfType(obj2.Animal, typeof(Lion));
            var lion = obj2.Animal as Lion;
            Debug.Assert(lion != null, "lion != null");
            Assert.AreEqual(lion.Speed, ((Lion)obj2.Animal).Speed);
            Assert.AreEqual(lion.Strength, ((Lion)obj2.Animal).Strength);
            Assert.AreEqual(lion.SightRange, ((Lion)obj2.Animal).SightRange);
        }
    }
}
