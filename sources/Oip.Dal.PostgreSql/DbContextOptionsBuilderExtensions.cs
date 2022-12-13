using Microsoft.EntityFrameworkCore;
using Oip.Dal.Core;

namespace Oip.Dal.PostgreSql;

public static class DbContextOptionsBuilderExtensions
{
    /// <summary>
    ///     Configures the context to use PostgreSql.
    /// </summary>
    public static DbContextOptionsBuilder UsePostgreSql(this DbContextOptionsBuilder builder, string connectionString)
    {
        return builder.UseNpgsql(connectionString, db => db
            .MigrationsAssembly(typeof(PostgreSqlOipContextFactory).Assembly.GetName().Name)
            .MigrationsHistoryTable(OipContext.MigrationsHistoryTable, OipContext.OipSchema));
    }
}