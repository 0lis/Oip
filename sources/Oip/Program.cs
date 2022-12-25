using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using Oip.Core.Configuration;
using Oip.Dal.Core;

internal class Program
{
    public static void Main(string[] args)
    {
        var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
        try
        {
            var builder = OipWebApplication.CreateBuilder(args, OipConfiguration.Configuration);
            builder.Services.AddOipServer();
            builder.Services.AddCors();
            var app = builder.BuildOip();
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<OipContext>();
                context.Database.Migrate();
            }

            app.UseAuthorization();

            app.MapControllerRoute(
                "default",
                "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");
            app.Run();
        }
        catch (Exception exception)
        {
            logger.Error(exception, "Stopped program because of exception");
            throw;
        }
        finally
        {
            LogManager.Shutdown();
        }
    }
}