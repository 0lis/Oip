using System;
using Microsoft.EntityFrameworkCore;
using Oip.Dal.Core;

namespace Oip.Dal.SqlServer;

public static class DbContextOptionsBuilderExtensions
{
    /// <summary>
    ///     Configures the context to use SqlServer.
    /// </summary>
    public static DbContextOptionsBuilder UseSqlServer(this DbContextOptionsBuilder builder, string connectionString,
        Type migrationsAssemblyMarker = default)
    {
        migrationsAssemblyMarker ??= typeof(SqlServerOipContextFactory);
        return builder.UseSqlServer(connectionString, db => db
            .MigrationsAssembly(migrationsAssemblyMarker.Assembly.GetName().Name)
            .MigrationsHistoryTable(OipContext.MigrationsHistoryTable, OipContext.OipSchema));
    }
}