using Microsoft.EntityFrameworkCore;
using Oip.Security.Dal.Sqlite.ContextFactory;

namespace Oip.Security.Dal.Sqlite;

public static class DbContextOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder UseSqlite(this DbContextOptionsBuilder builder,
        string connectionString = Constants.DefaultConnectionString)
    {
        return builder.UseSqlite(connectionString, db => db
            .MigrationsAssembly(typeof(SqliteBaseDbContextFactory<>).Assembly.GetName().Name)
            .MigrationsHistoryTable(Constants.MigrationsHistoryTable));
    }
}