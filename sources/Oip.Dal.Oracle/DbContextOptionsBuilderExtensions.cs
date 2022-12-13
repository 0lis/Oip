using Microsoft.EntityFrameworkCore;
using Oip.Dal.Core;

namespace Oip.Dal.Oracle;

public static class DbContextOptionsBuilderExtensions
{
    /// <summary>
    ///     Configures the context to use Oracle.
    /// </summary>
    public static DbContextOptionsBuilder UseOracle(this DbContextOptionsBuilder builder, string connectionString)
    {
        return builder.UseOracle(connectionString, db => db
            .MigrationsAssembly(typeof(OracleOipContextFactory).Assembly.GetName().Name)
            .MigrationsHistoryTable(OipContext.MigrationsHistoryTable, OipContext.OipSchema));
    }
}