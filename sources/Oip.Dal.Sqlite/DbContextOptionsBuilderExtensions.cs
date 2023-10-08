using Microsoft.EntityFrameworkCore;

namespace Oip.Dal.Sqlite;

public static class DbContextOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder UseSqlite(this DbContextOptionsBuilder builder,
        string connectionString = "Data Source=Oip.sqlite.db;Cache=Shared;")
    {
        return builder.UseSqlite(connectionString, db => db
            .MigrationsAssembly(typeof(SqliteOipContextFactory).Assembly.GetName().Name)
            .MigrationsHistoryTable(OipContext.MigrationsHistoryTable));
    }
}