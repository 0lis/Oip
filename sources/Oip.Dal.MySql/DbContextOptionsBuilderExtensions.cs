using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Oip.Dal.MySql;

public static class DbContextOptionsBuilderExtensions
{
    /// <summary>
    ///     Configures the context to use MySql
    /// </summary>
    public static DbContextOptionsBuilder UseMySql(this DbContextOptionsBuilder builder, string connectionString)
    {
        return builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), db => db
            .MigrationsAssembly(typeof(MySqlOipContextFactory).Assembly.GetName().Name)
            .MigrationsHistoryTable(OipContext.MigrationsHistoryTable, OipContext.OipSchema)
            .SchemaBehavior(MySqlSchemaBehavior.Ignore));
    }
}