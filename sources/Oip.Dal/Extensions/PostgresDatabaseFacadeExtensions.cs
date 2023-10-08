using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Oip.Dal.Extensions;

internal static class PostgresDatabaseFacadeExtensions
{
    public static bool IsPostgres(this DatabaseFacade database)
    {
        return database.ProviderName == "Npgsql.EntityFrameworkCore.PostgreSQL";
    }
}