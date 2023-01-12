using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Oip.Dal.MySql;

public class MySqlOipContextFactory : IDesignTimeDbContextFactory<OipContext>
{
    public OipContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<OipContext>();
        var connectionString = args.Any()
            ? args[0]
            : throw new InvalidOperationException(
                "Please specify a connection string. E.g. dotnet ef database update -- \"Server=localhost;Port=3306;Database=Oip;User=root;Password=password\"");
        var serverVersion = args.Length >= 2 ? args[1] : null;

        builder.UseMySql(
            connectionString,
            serverVersion != null ? ServerVersion.Parse(serverVersion) : ServerVersion.AutoDetect(connectionString),
            db => db
                .MigrationsAssembly(typeof(MySqlOipContextFactory).Assembly.GetName().Name)
                .MigrationsHistoryTable(OipContext.MigrationsHistoryTable)
                .SchemaBehavior(MySqlSchemaBehavior.Ignore));

        return new OipContext(builder.Options);
    }
}