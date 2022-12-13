using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Oip.Dal.Core;

namespace Oip.Dal.SqlServer;

public class SqlServerOipContextFactory : IDesignTimeDbContextFactory<OipContext>
{
    public OipContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<OipContext>();
        var connectionString = args.Any()
            ? args[0]
            : throw new InvalidOperationException(
                "Please specify a connection string. E.g. dotnet ef database update -- \"Server=Local;Database=elsa\"");
        builder.UseSqlServer(connectionString, db => db
            .MigrationsAssembly(typeof(SqlServerOipContextFactory).Assembly.GetName().Name)
            .MigrationsHistoryTable(OipContext.MigrationsHistoryTable, OipContext.OipSchema));
        return new OipContext(builder.Options);
    }
}