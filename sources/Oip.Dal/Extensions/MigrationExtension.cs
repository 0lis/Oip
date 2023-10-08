using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Oip.Dal.Extensions;

public static class MigrateDatabaseExtension
{
    public static WebApplication MigrateDatabase(this WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateScope();
        using var appContext = scope.ServiceProvider.GetRequiredService<OipContext>();
        appContext.Database.Migrate();
        return webApplication;
    }
}