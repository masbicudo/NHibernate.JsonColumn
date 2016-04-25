using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NHibernate.JsonColumn.Tests.Code;

namespace NHibernate.JsonColumn.Tests
{
    public class UnitTestBase
    {
        public ISession Session { get; set; }
        public SessionProviderNH SessionProvider { get; private set; }

        [TestInitialize]
        public void TestInitialize()
        {
            JsonConvert.DefaultSettings = FluentJsonNet.JsonMaps.GetDefaultSettings(typeof(UnitTestBase).Assembly.GetTypes());
            this.SessionProvider = new SessionProviderNH();
            this.Session = this.SessionProvider.SessionFactory.OpenSession();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.Session.Dispose();
        }
    }
}