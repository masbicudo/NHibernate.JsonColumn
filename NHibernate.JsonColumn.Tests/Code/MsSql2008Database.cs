using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace NHibernate.JsonColumn.Tests.Code
{
    public class MsSql2008Database : Database
    {
        public override void CreateDatabaseMedia()
        {
            var dirs = this.GetSqlServerDirectories();
            var sqlServerDataDirectory = dirs.DefaultData;
            var parts = this.GetConnectionStringParts();
            var databaseName = parts["Initial Catalog"];
            parts.Remove("Initial Catalog");
            var connStr = string.Join(";", parts.Select(kv => kv.Key + "=" + kv.Value));

            string createDatabaseScript = $@"
IF (SELECT DB_ID('{databaseName}')) IS NULL
    CREATE DATABASE {databaseName}
    ON PRIMARY
    (
        NAME = {databaseName}_Data,
        FILENAME = '{Path.Combine(sqlServerDataDirectory, databaseName + ".mdf")}',
        SIZE = 5MB,
        FILEGROWTH = {10}
    )
    LOG ON (
        NAME = {databaseName}_Log,
        FILENAME = '{Path.Combine(sqlServerDataDirectory, databaseName + ".ldf")}',
        SIZE = 1MB,
        FILEGROWTH = {5}
    )";

            this.ExecuteDbScript(createDatabaseScript, connStr);
        }

        private Dictionary<string, string> GetConnectionStringParts()
        {
            return this.ConnectionString.Split(';')
                .Select(entry => entry.Split(new[] { '=' }, 2))
                .Where(a => a != null && a.Length == 2 && a.All(s => !string.IsNullOrWhiteSpace(s)))
                .ToDictionary(a => a[0].Trim(), a => a[1], StringComparer.InvariantCultureIgnoreCase);
        }

        private void ExecuteDbScript(string sqlScript, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sqlScript, conn))
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public class SqlDirs
        {
            public string DefaultData { get; set; }
            public string DefaultLog { get; set; }
            public string DefaultBackup { get; set; }
        }

        public virtual SqlDirs GetSqlServerDirectories()
        {
            var queryString = @"
declare @DefaultData nvarchar(512)
exec master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'DefaultData', @DefaultData output

declare @DefaultLog nvarchar(512)
exec master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'DefaultLog', @DefaultLog output

declare @DefaultBackup nvarchar(512)
exec master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'BackupDirectory', @DefaultBackup output

declare @MasterData nvarchar(512)
exec master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer\Parameters', N'SqlArg0', @MasterData output
select @MasterData=substring(@MasterData, 3, 255)
select @MasterData=substring(@MasterData, 1, len(@MasterData) - charindex('\', reverse(@MasterData)))

declare @MasterLog nvarchar(512)
exec master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer\Parameters', N'SqlArg2', @MasterLog output
select @MasterLog=substring(@MasterLog, 3, 255)
select @MasterLog=substring(@MasterLog, 1, len(@MasterLog) - charindex('\', reverse(@MasterLog)))

select 
    isnull(@DefaultData, @MasterData) DefaultData, 
    isnull(@DefaultLog, @MasterLog) DefaultLog,
    isnull(@DefaultBackup, @MasterLog) DefaultBackup
";
            var parts = this.GetConnectionStringParts();
            parts.Remove("Initial Catalog");
            var connStr = string.Join(";", parts.Select(kv => kv.Key + "=" + kv.Value));
            using (var connection = new SqlConnection(connStr))
            {
                var command = new System.Data.SqlClient.SqlCommand(queryString, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        return new SqlDirs
                        {
                            DefaultData = reader["DefaultData"].ToString(),
                            DefaultLog = reader["DefaultLog"].ToString(),
                            DefaultBackup = reader["DefaultBackup"].ToString(),
                        };
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }

            return null;
        }

        public MsSql2008Database(string connectionString)
            : base(connectionString)
        {
        }
    }
}