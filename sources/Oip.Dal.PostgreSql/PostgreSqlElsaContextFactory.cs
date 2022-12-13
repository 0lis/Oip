using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Oip.Dal.Core;

namespace Oip.Dal.PostgreSql;

public class PostgreSqlOipContextFactory : IDesignTimeDbContextFactory<OipContext>
{
    public OipContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<OipContext>();
        var connectionString = args.Any()
            ? args[0]
            : "Server=127.0.0.1;Port=5432;Database=elsa;User Id=postgres;Password=password;";

        builder.UseNpgsql(
            connectionString,
            db => db.MigrationsAssembly(typeof(PostgreSqlOipContextFactory).Assembly.GetName().Name)
                .MigrationsHistoryTable(OipContext.MigrationsHistoryTable, OipContext.OipSchema));

        return new OipContext(builder.Options);
    }
}