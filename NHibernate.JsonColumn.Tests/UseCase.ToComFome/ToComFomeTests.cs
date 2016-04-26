using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.Models;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome
{
    [TestClass]
    public class ToComFomeTests : UnitTestBase
    {
        [TestMethod]
        public void TestMethod_SavePropertyAsJson()
        {
            var obj = TestData.GetTestProductModels();
            this.Session.Save(obj);
        }

        [TestMethod]
        public void TestMethod_LoadPropertyWithJson()
        {
            // SETUP - first we need to save to the database
            ProductModel obj = TestData.GetTestProductModels();

            using (var session = this.SessionProvider.SessionFactory.OpenSession())
                session.Save(obj);

            // TEST - load the previously saved entity
            var obj2 = this.Session.Get<ProductModel>(obj.Id);

            // ASSERT
            Assert.AreEqual(obj.Photo, obj2.Photo);
        }
    }
}
