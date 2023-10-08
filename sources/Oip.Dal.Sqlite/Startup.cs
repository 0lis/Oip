using Microsoft.EntityFrameworkCore;

namespace Oip.Dal.Sqlite;

public class Startup : EntityFrameworkCoreStartupBase
{
    protected override string ProviderName => "Sqlite";

    protected override string GetDefaultConnectionString()
    {
        return "Data Source=Oip.sqlite.db;Cache=Shared;";
    }

    protected override void Configure(DbContextOptionsBuilder options, string connectionString)
    {
        options.UseSqlite(connectionString);
    }
}