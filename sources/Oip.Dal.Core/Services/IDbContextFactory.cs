namespace Oip.Dal.Core.Services;

public interface IContextFactory<out TContext>
{
    TContext CreateDbContext();
}