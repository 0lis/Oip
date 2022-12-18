using Microsoft.EntityFrameworkCore;

namespace Oip.Security.Dal.Sqlite;

public class Startup : EntityFrameworkCoreStartupBase
{
    protected override string ProviderName => "Sqlite";

    protected override string GetDefaultConnectionString()
    {
        return Constants.DefaultConnectionString;
    }

    protected override void Configure(DbContextOptionsBuilder options, string connectionString)
    {
        SqliteDbContextOptionsBuilderExtensions.UseSqlite(options, connectionString);
    }
}