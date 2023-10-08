using Oip.Dal.Entity;

namespace Oip.Dal.Repositories;

public class UomRepository : BaseRepository<Uom>
{
    private readonly OipContext _oipContext;

    public UomRepository(OipContext dbContext) : base(dbContext)
    {
        _oipContext = dbContext;
    }
}