using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

namespace Oip.Dal.Extensions;

public static class QueryableBulkExtensions
{
    public static async Task<int> BatchDeleteWithWorkAroundAsync<T>(this IQueryable<T> queryable, DbContext oipContext,
        CancellationToken cancellationToken = default) where T : class
    {
        if (!oipContext.Database.IsPostgres() && !oipContext.Database.IsMySql() && !oipContext.Database.IsOracle())
            return await queryable.BatchDeleteAsync(cancellationToken);
        // Need this workaround https://github.com/borisdj/EFCore.BulkExtensions/issues/553 is solved.
        // Oracle also https://github.com/borisdj/EFCore.BulkExtensions/issues/375
        var records = await queryable.ToListAsync(cancellationToken);

        foreach (var record in records)
            oipContext.Remove(record);

        return records.Count;
    }
}