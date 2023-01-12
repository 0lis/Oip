using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oip.Dal.Entity;

namespace Oip.Dal.Configuration;

public class ModuleConfiguration : IEntityTypeConfiguration<Module>
{
    public void Configure(EntityTypeBuilder<Module> builder)
    {
        builder.HasIndex(x => new { x.Id }).HasDatabaseName($"IX_{nameof(Module)}_{nameof(Module.Id)}").IsUnique();
        builder.HasIndex(x => x.Name).HasDatabaseName($"IX_{nameof(Module)}_{nameof(Module.Name)}");
    }
}