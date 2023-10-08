using System.Linq;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using Oip.Dal.Configuration;
using Oip.Dal.Entity;
using Oip.Dal.Extensions;

namespace Oip.Dal;

public class OipContext : DbContext
{
    public const string OipSchema = "Oip";
    public const string MigrationsHistoryTable = "OipMigrationsHistory";

    public OipContext(DbContextOptions options) : base(options)
    {
    }

    protected virtual string Schema => OipSchema;
    public DbSet<Uom> Uoms => default!;
    public DbSet<Module> Modules => default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OipContext).Assembly);

        if (Database.IsSqlite())
            // SQLite does not have proper support for DateTimeOffset via Entity Framework Core, see the limitations
            // here: https://docs.microsoft.com/en-us/ef/core/providers/sqlite/limitations#query-limitations
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties().Where(p =>
                    p.PropertyType == typeof(Instant) || p.PropertyType == typeof(Instant?));
                foreach (var property in properties)
                    modelBuilder
                        .Entity(entityType.Name)
                        .Property(property.Name)
                        .HasConversion(ValueConverters.SqliteInstantConverter);
            }

        if (Database.IsOracle())
            // In order to use data more than 2000 char we have to use NCLOB. In oracle we have to explicitly say the column is NCLOB otherwise it would be considered nvarchar(2000).
            modelBuilder.Entity<Uom>().Property(x => x.LocalizedName).HasColumnType("NCLOB");
    }
}