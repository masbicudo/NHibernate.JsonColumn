using System.Linq;
using Either_For_JsonNet;
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
            var settings = FluentJsonNet.JsonMaps.GetDefaultSettings(typeof(UnitTestBase).Assembly.GetTypes())();
            settings.Converters = settings.Converters.Concat(new[] { new EitherJsonConverter(), }).ToList().AsReadOnly();
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = settings.Converters,
                ContractResolver = settings.ContractResolver,
            };
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