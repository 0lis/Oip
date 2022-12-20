using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Oip.Security.Common.Configuration.Helpers;
using Oip.Security.Dal.Common.DbContexts;
using Oip.Security.Dal.Common.Entities.Identity;
using Oip.Security.Dal.Configuration;
using Oip.Security.Dal.Shared.Entities.Identity;
using Oip.Security.Dal.Shared.Helpers;
using Serilog;
using Skoruba.IdentityServer4.Shared.Configuration.Helpers;

namespace Oip.Security;

public class Program
{
    private const string SeedArgs = "/seed";
    private const string MigrateOnlyArgs = "/migrateonly";

    public static async Task Main(string[] args)
    {
        var configuration = GetConfiguration(args);

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        try
        {
            DockerHelpers.ApplyDockerConfiguration(configuration);

            var host = CreateHostBuilder(args).Build();

            var migrationComplete = await ApplyDbMigrationsWithDataSeedAsync(args, configuration, host);
            if (args.Any(x => x == MigrateOnlyArgs))
            {
                await host.StopAsync();
                if (!migrationComplete) Environment.ExitCode = -1;

                return;
            }

            await host.RunAsync();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Host terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static async Task<bool> ApplyDbMigrationsWithDataSeedAsync(string[] args, IConfiguration configuration,
        IHost host)
    {
        var applyDbMigrationWithDataSeedFromProgramArguments = args.Any(x => x == SeedArgs);
        if (applyDbMigrationWithDataSeedFromProgramArguments) args = args.Except(new[] { SeedArgs }).ToArray();

        var seedConfiguration = configuration.GetSection(nameof(SeedConfiguration)).Get<SeedConfiguration>();
        var databaseMigrationsConfiguration = configuration.GetSection(nameof(DatabaseMigrationsConfiguration))
            .Get<DatabaseMigrationsConfiguration>();

        return await DbMigrationHelpers
            .ApplyDbMigrationsWithDataSeedAsync<IdentityServerConfigurationDbContext, AdminIdentityDbContext,
                IdentityServerPersistedGrantDbContext, AdminLogDbContext, AdminAuditLogDbContext,
                IdentityServerDataProtectionDbContext, UserIdentity, UserIdentityRole>(host,
                applyDbMigrationWithDataSeedFromProgramArguments, seedConfiguration, databaseMigrationsConfiguration);
    }

    private static IConfiguration GetConfiguration(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var isDevelopment = environment == Environments.Development;

        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{environment}.json", true, true)
            .AddJsonFile("serilog.json", true, true)
            .AddJsonFile($"serilog.{environment}.json", true, true);

        if (isDevelopment) configurationBuilder.AddUserSecrets<Startup>(true);

        var configuration = configurationBuilder.Build();

        configuration.AddAzureKeyVaultConfiguration(configurationBuilder);

        configurationBuilder.AddCommandLine(args);
        configurationBuilder.AddEnvironmentVariables();

        return configurationBuilder.Build();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, configApp) =>
            {
                var configurationRoot = configApp.Build();

                configApp.AddJsonFile("serilog.json", true, true);
                configApp.AddJsonFile("identitydata.json", true, true);
                configApp.AddJsonFile("identityserverdata.json", true, true);

                var env = hostContext.HostingEnvironment;

                configApp.AddJsonFile($"serilog.{env.EnvironmentName}.json", true, true);
                configApp.AddJsonFile($"identitydata.{env.EnvironmentName}.json", true, true);
                configApp.AddJsonFile($"identityserverdata.{env.EnvironmentName}.json", true, true);

                if (env.IsDevelopment()) configApp.AddUserSecrets<Startup>(true);

                configurationRoot.AddAzureKeyVaultConfiguration(configApp);

                configApp.AddEnvironmentVariables();
                configApp.AddCommandLine(args);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureKestrel(options => options.AddServerHeader = false);
                webBuilder.UseStartup<Startup>();
            })
            .UseSerilog((hostContext, loggerConfig) =>
            {
                loggerConfig
                    .ReadFrom.Configuration(hostContext.Configuration)
                    .Enrich.WithProperty("ApplicationName", hostContext.HostingEnvironment.ApplicationName);
            });
    }
}