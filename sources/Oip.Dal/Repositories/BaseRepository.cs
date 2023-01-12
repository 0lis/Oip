using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Oip.Dal.Repositories;

public class BaseRepository<TEntity> where TEntity : class
{
    protected BaseRepository(DbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = dbContext.Set<TEntity>();
    }

    private DbContext DbContext { get; }
    private DbSet<TEntity> DbSet { get; }

    public void Insert(TEntity entity)
    {
        var e = DbSet.Add(entity);
        DbContext.SaveChanges();
        e.State = EntityState.Detached;
    }

    public void Update(TEntity entity)
    {
        var e = DbContext.Update(entity);
        DbContext.SaveChanges();
        e.State = EntityState.Detached;
    }

    public void Delete(TEntity entity)
    {
        var e = DbContext.Remove(entity);
        DbContext.SaveChanges();
        e.State = EntityState.Detached;
    }

    public void Upsert(TEntity entity)
    {
        if (DbSet.Contains(entity))
            Update(entity);
        else
            Insert(entity);
    }

    public IEnumerable<TEntity> ToList()
    {
        return DbSet.ToList();
    }
}