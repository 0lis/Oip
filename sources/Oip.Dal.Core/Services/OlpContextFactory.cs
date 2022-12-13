using Microsoft.EntityFrameworkCore;

namespace Oip.Dal.Core.Services;

public class OipContextFactory<TOipContext> : IOipContextFactory where TOipContext : OipContext
{
    private readonly IDbContextFactory<TOipContext> _contextFactory;

    public OipContextFactory(IDbContextFactory<TOipContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public OipContext CreateDbContext()
    {
        return _contextFactory.CreateDbContext();
    }
}