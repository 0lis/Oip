namespace Oip.Dal.Services;

public interface IContextFactory<out TContext>
{
    TContext CreateDbContext();
}