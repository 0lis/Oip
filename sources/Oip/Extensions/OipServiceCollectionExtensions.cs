using Microsoft.Extensions.Hosting.Internal;
using Oip.Core.Configuration;
using Oip.Core.Runtime;
using Oip.Dal.Core;
using Oip.Dal.PostgreSql;
using Oip.Dal.Sqlite;
using Oip.Dal.SqlServer;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
///     Extension for asp net for planform
/// </summary>
public static class OipServiceCollectionExtensions
{
    /// <summary>
    ///     Extension for asp net for planform
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configure"></param>
    /// <returns></returns>
    public static IServiceCollection AddOipServer(this IServiceCollection services,
        Action<OipOptionsBuilder>? configure = default)
    {
        return services
            .AddSingleton<IHostApplicationLifetime, ApplicationLifetime>()
            .AddStartupRunner()
            .AddDbContext<OipContext>(ef =>
            {
                switch (OipConfiguration.Configuration.Storage)
                {
                    case "MSSQL":
                        ef.UseSqlServer(OipConfiguration.Configuration.ConnectionString);
                        break;
                    case "PostgreSql":
                        ef.UsePostgreSql(OipConfiguration.Configuration.ConnectionString);
                        break;
                    case "Sqlite":
                        ef.UseSqlite(OipConfiguration.Configuration.ConnectionString);
                        break;
                    case "Memory":
                        //ef.UseInMemoryDb();
                        break;
                }
            });
    }
}