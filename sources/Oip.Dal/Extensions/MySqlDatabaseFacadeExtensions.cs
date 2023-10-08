using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Oip.Dal.Extensions;

internal static class MySqlDatabaseFacadeExtensions
{
    public static bool IsMySql(this DatabaseFacade database)
    {
        return database.ProviderName == "Pomelo.EntityFrameworkCore.MySql";
    }
}