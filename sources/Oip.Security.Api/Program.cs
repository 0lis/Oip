using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Oip.Security.Common.Configuration.Helpers;
using Serilog;
using Skoruba.IdentityServer4.Shared.Configuration.Helpers;

namespace Oip.Security.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var configuration = GetConfiguration(args);

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
        try
        {
            DockerHelpers.ApplyDockerConfiguration(configuration);

            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
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

                var env = hostContext.HostingEnvironment;

                configApp.AddJsonFile($"serilog.{env.EnvironmentName}.json", true, true);

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