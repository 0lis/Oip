using Oip.Dal.Entity;

namespace Oip.Dal.Repositories;

public class ModuleRepository : BaseRepository<Module>
{
    private readonly OipContext _oipContext;

    public ModuleRepository(OipContext dbContext) : base(dbContext)
    {
        _oipContext = dbContext;
    }
}