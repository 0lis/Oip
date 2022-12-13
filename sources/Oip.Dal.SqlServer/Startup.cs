using Microsoft.EntityFrameworkCore;
using Oip.Dal.Core;

namespace Oip.Dal.SqlServer;

public class Startup : EntityFrameworkCoreStartupBase
{
    protected override string ProviderName => "SqlServer";

    protected override void Configure(DbContextOptionsBuilder options, string connectionString)
    {
        options.UseSqlServer(connectionString);
    }
}