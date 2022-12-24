using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using Oip.Core.Configuration;
using Oip.Dal.Core;

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
    app.UseCors(corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin());
    app.UseAuthorization();

    app.MapControllerRoute(
        "default",
        "{controller}/{action=Index}/{id?}");

    app.MapFallbackToFile("index.html");
    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}