using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oip.Dal.Core.Entity;

namespace Oip.Dal.Core.Configuration;

public class UomConfiguration : IEntityTypeConfiguration<Uom>
{
    public void Configure(EntityTypeBuilder<Uom> builder)
    {
        builder.HasIndex(x => new { x.Id }).HasDatabaseName($"IX_{nameof(Uom)}_{nameof(Uom.Id)}").IsUnique();
        builder.HasIndex(x => x.Name).HasDatabaseName($"IX_{nameof(Uom)}_{nameof(Uom.Name)}");
    }
}