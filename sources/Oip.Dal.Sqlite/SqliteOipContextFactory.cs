using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Oip.Dal.Core;

namespace Oip.Dal.Sqlite;

public class SqliteOipContextFactory : IDesignTimeDbContextFactory<OipContext>
{
    public OipContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<OipContext>();
        var connectionString = args.Any() ? args[0] : "Data Source=Oip.db;Cache=Shared";

        builder.UseSqlite(connectionString, db => db
            .MigrationsAssembly(typeof(SqliteOipContextFactory).Assembly.GetName().Name)
            .MigrationsHistoryTable(OipContext.MigrationsHistoryTable));

        return new OipContext(builder.Options);
    }
}