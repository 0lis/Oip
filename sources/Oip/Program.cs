using NLog;
using NLog.Web;
using Oip.Core.Configuration;
using Oip.Dal.Core.Extensions;

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

            app.MigrateDatabase();

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