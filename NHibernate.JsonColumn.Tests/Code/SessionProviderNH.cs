using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.JsonColumn.Tests.NHMaps;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using Configuration = NHibernate.Cfg.Configuration;

namespace NHibernate.JsonColumn.Tests.Code
{
    /// <summary>
    /// Configures NHibernate.
    /// This is the built-in NHibernate code configuration style.
    /// See <see cref="SessionProviderFluentNH"/> for the same thing using Fluent-NHibernate.
    /// </summary>
    public class SessionProviderNH
    {
        public Configuration NHConfiguration { get; }

        public ISessionFactory SessionFactory { get; }

        public SessionProviderNH()
        {
            var s = Stopwatch.StartNew();
            try
            {
                #region NHibernate configuration

                this.NHConfiguration = ConfigureNHibernate();

                this.SessionFactory = this.NHConfiguration.BuildSessionFactory();

                string connStr;
                if (!this.NHConfiguration.Properties.TryGetValue(Environment.ConnectionString, out connStr))
                    if (this.NHConfiguration.Properties.TryGetValue(Environment.ConnectionStringName, out connStr))
                        connStr = ConfigurationManager.ConnectionStrings[connStr]?.ConnectionString;

                new MsSql2008Database(connStr).CreateDatabaseMedia();

                new SchemaUpdate(this.NHConfiguration).Execute(false, true);

                #endregion
            }
            finally
            {
                s.Stop();
                Debug.Print($"Fluently.Configure() - {s.ElapsedMilliseconds}ms");
            }
        }

        private static Configuration ConfigureNHibernate()
        {
            var configure = new Configuration();
            configure.SessionFactoryName("BuildIt");

            configure.DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2008Dialect>();
                db.Driver<Sql2008ClientDriver>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.IsolationLevel = IsolationLevel.ReadCommitted;

                db.ConnectionStringName = "TestDB";
                db.Timeout = 10;

                // enabled for testing
                db.LogFormattedSql = true;
                db.LogSqlInConsole = true;
                db.AutoCommentSql = true;
            });

            var mapping = GetMappings();
            configure.AddDeserializedMapping(mapping, "NHSchemaTest");
            SchemaMetadataUpdater.QuoteTableAndColumns(configure);

            return configure;
        }

        private static HbmMapping GetMappings()
        {
            var mapper = new ModelMapper();

            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            return mapping;
        }
    }
}