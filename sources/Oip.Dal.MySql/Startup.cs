using Microsoft.EntityFrameworkCore;
using Oip.Dal.Core;

namespace Oip.Dal.MySql;

public class Startup : EntityFrameworkCoreStartupBase
{
    protected override string ProviderName => "MySql";

    protected override void Configure(DbContextOptionsBuilder options, string connectionString)
    {
        options.UseMySql(connectionString);
    }
}