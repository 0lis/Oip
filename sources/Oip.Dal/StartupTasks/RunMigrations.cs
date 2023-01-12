using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Oip.Core.Startup;
using Oip.Dal.Services;

namespace Oip.Dal.StartupTasks;

/// <summary>
///     Executes EF Core migrations.
/// </summary>
public class RunMigrations : IStartupTask
{
    private readonly IOipContextFactory _dbContextFactory;

    public RunMigrations(IOipContextFactory dbContextFactoryFactory)
    {
        _dbContextFactory = dbContextFactoryFactory;
    }

    public int Order => 0;

    public async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();
        await dbContext.Database.MigrateAsync(cancellationToken);
        await dbContext.DisposeAsync();
    }
}