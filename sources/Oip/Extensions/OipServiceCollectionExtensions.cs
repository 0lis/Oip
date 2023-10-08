using Microsoft.Extensions.Hosting.Internal;
using Oip.Bl.Services;
using Oip.Core.Configuration;
using Oip.Core.Runtime;
using Oip.Dal;
using Oip.Dal.PostgreSql;
using Oip.Dal.Repositories;
using Oip.Dal.Sqlite;
using Oip.Dal.SqlServer;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
///     Extension for asp net for platform
/// </summary>
public static class OipServiceCollectionExtensions
{
    /// <summary>
    ///     Extension for asp net for platform
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configure"></param>
    /// <returns></returns>
    public static IServiceCollection AddOipServer(this IServiceCollection services,
        Action<OipOptionsBuilder>? configure = default)
    {
        var serviceCollection = services
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
            })
            .AddScoped<UomService>()
            .AddScoped<UomRepository>()
            .AddScoped<ModuleRepository>()
            .AddScoped<ModuleService>();

        return serviceCollection;
    }
}