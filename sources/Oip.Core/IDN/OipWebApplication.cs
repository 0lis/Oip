using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class OipWebApplication
{
    public static WebApplicationBuilder CreateBuilder(string [] args, object config)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Configuration.Bind(config);
        builder.Services.AddSwaggerGen(options =>
        {
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
        });
        builder.Services.AddControllersWithViews();
        builder.Logging.ClearProviders();
        builder.Host.UseNLog();

        return builder;
    }
}