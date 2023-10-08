using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Oip.Dal.Oracle;

public class OracleOipContextFactory : IDesignTimeDbContextFactory<OipContext>
{
    public OipContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<OipContext>();
        var connectionString = args.Any()
            ? args[0]
            : "Server=127.0.0.1;Port=5432;Database=elsa;User Id=oracle;Password=password;";

        builder.UseOracle(
            connectionString,
            db => db.MigrationsAssembly(typeof(OracleOipContextFactory).Assembly.GetName().Name)
                .MigrationsHistoryTable(OipContext.MigrationsHistoryTable, OipContext.OipSchema));

        return new OipContext(builder.Options);
    }
}