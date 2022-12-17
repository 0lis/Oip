using System;
using System.Reflection;
using Oip.Security.EntityFramework.Configuration.Configuration;
using SqlMigrationAssembly = Oip.Security.EntityFramework.SqlServer.Helpers.MigrationAssembly;
using MySqlMigrationAssembly = Oip.Security.EntityFramework.MySql.Helpers.MigrationAssembly;
using PostgreSQLMigrationAssembly = Oip.Security.EntityFramework.PostgreSQL.Helpers.MigrationAssembly;

namespace Oip.Security.Configuration.Database;

public static class MigrationAssemblyConfiguration
{
    public static string GetMigrationAssemblyByProvider(DatabaseProviderConfiguration databaseProvider)
    {
        return databaseProvider.ProviderType switch
        {
            DatabaseProviderType.SqlServer => typeof(SqlMigrationAssembly).GetTypeInfo().Assembly.GetName().Name,
            DatabaseProviderType.PostgreSql => typeof(PostgreSQLMigrationAssembly).GetTypeInfo()
                .Assembly.GetName()
                .Name,
            DatabaseProviderType.MySql => typeof(MySqlMigrationAssembly).GetTypeInfo().Assembly.GetName().Name,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}