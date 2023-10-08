using Microsoft.EntityFrameworkCore;

namespace Oip.Dal.SqlServer;

public class Startup : EntityFrameworkCoreStartupBase
{
    protected override string ProviderName => "SqlServer";

    protected override void Configure(DbContextOptionsBuilder options, string connectionString)
    {
        options.UseSqlServer(connectionString);
    }
}