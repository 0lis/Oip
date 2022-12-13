using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oip.Dal.Core.Entity;

namespace Oip.Dal.Core.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => new { x.Id }).HasDatabaseName($"IX_{nameof(User)}_{nameof(User.Id)}").IsUnique();
        builder.HasIndex(x => x.Name).HasDatabaseName($"IX_{nameof(User)}_{nameof(User.Name)}");
        builder.Property(x => x.FullName).HasComment("Full user name");
    }
}