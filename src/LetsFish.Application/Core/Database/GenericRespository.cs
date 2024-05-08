using System.Linq.Expressions;

namespace LetsFish.Application.Core.Database;

internal class GenericRespository<TEntity> where TEntity : class
{
    internal LetsFishContext _letsFishContext;
    internal DbSet<TEntity> dbSet;

    public GenericRespository(LetsFishContext letsFishContext)
    {
        _letsFishContext = letsFishContext;
        this.dbSet = _letsFishContext.Set<TEntity>();
    }

    public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }
        else
        {
            return query.ToList();
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public virtual async Task<TEntity> GetByID(object id)
    {
        return await dbSet.FindAsync(id);
    }

    public virtual async Task InsertAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
    }

    public virtual void Delete(object id)
    {
        TEntity entityToDelete = dbSet.Find(id);
        Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (_letsFishContext.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }
        dbSet.Remove(entityToDelete);
    }

    public virtual void Update(TEntity entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        _letsFishContext.Entry(entityToUpdate).State = EntityState.Modified;
    }

}
