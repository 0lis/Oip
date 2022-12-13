using Microsoft.EntityFrameworkCore;
using Oip.Dal.Core;

namespace Oip.Dal.PostgreSql;

public class Startup : EntityFrameworkCoreStartupBase
{
    protected override string ProviderName => "PostgreSql";

    protected override void Configure(DbContextOptionsBuilder options, string connectionString)
    {
        options.UsePostgreSql(connectionString);
    }
}