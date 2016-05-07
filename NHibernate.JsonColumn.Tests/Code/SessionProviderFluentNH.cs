using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using Configuration = NHibernate.Cfg.Configuration;

namespace NHibernate.JsonColumn.Tests.Code
{
    /// <summary>
    /// Configures NHibernate.
    /// This is the Fluent-NHibernate code configuration style.
    /// See <see cref="SessionProviderNH"/> for the same thing using pure NHibernate.
    /// </summary>
    public class SessionProviderFluentNH
    {
        public Configuration NHConfiguration { get; }

        public ISessionFactory SessionFactory { get; }

        public SessionProviderFluentNH()
        {
            var connStrName = "TestDB";

            var s = Stopwatch.StartNew();
            try
            {
                var connStr = ConfigurationManager.ConnectionStrings[connStrName].ConnectionString;
                new MsSqlDatabase(connStr).CreateDatabaseMedia();
                Configuration gotConfig = null;
                this.SessionFactory = Fluently.Configure()
                    .Database(
                        MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey(connStrName)))
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .ExposeConfiguration(
                        cfg =>
                        {
                            gotConfig = cfg;
                            //new MsSqlDatabase(cfg.Properties[Environment.ConnectionString]).CreateDatabaseMedia();
                            new SchemaUpdate(cfg).Execute(false, true);
                        })
                    //.ExposeConfiguration(cfg => cfg.Properties.Add("use_proxy_validator", "false"))
                    .BuildSessionFactory();

                this.NHConfiguration = gotConfig;
            }
            finally
            {
                s.Stop();
                Debug.Print($"Fluently.Configure() - {s.ElapsedMilliseconds}ms");
            }
        }
    }
}