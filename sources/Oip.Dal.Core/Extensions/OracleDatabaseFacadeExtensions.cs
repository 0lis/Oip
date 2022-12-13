using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Oip.Dal.Core.Extensions;

internal static class OracleDatabaseFacadeExtensions
{
    public static bool IsOracle(this DatabaseFacade database)
    {
        return database.ProviderName == "Oracle.EntityFrameworkCore";
    }
}