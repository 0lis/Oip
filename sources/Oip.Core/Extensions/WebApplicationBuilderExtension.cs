using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class OipWebApplication
{
    public static WebApplicationBuilder CreateBuilder(string[] args, object config)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Configuration.Bind(config);
        builder.Services.AddSwaggerGen(options =>
        {
            var path = Path.GetDirectoryName(typeof(OipWebApplication).Assembly.Location);
            if (path == null) return;
            var filesPaths = Directory.GetFiles(path, "*.xml");
            foreach (var filePath in filesPaths) options.IncludeXmlComments(filePath);
        });
        builder.Services.AddControllersWithViews();
        builder.Logging.ClearProviders();
        builder.Host.UseNLog();
        return builder;
    }
}