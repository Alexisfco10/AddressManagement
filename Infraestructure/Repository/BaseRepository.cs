using System.Linq.Expressions;
using Application.Repository;
using Domain.Models;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository;

public abstract class Repository<TEntity> : IRepository<TEntity>
    where TEntity : BaseModel
{
    private readonly AddressManagementDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    protected Repository(AddressManagementDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dbSet = _dbContext.Set<TEntity>();
    }

    public virtual async Task Add(TEntity model)
    {
        await _dbSet.AddAsync(model);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if (include is not null)
            query = include(query);

        return await query.ToListAsync();
    }

    public virtual async Task<TEntity?> Get(long id, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
    {
        if (include is null)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.Id == id);
        }

        IQueryable<TEntity> query = include(_dbSet);
        return await query.FirstOrDefaultAsync(m => m.Id == id);
    }

    public virtual void Update(TEntity model)
    {
        if (_dbContext.Entry(model).State == EntityState.Detached)
            _dbSet.Attach(model);

        _dbContext.Entry(model).State = EntityState.Modified;
    }

    public void Delete(TEntity model)
    {
        _dbSet.Remove(model);
    }

    public virtual async Task<IEnumerable<TEntity>> Search(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
    {
        IQueryable<TEntity> query = _dbSet;
        if (include is not null)
            query = include(query);

        return await query.Where(predicate).ToListAsync();
    }

    public async Task Save()
    {
        await _dbContext.SaveChangesAsync();
    }
}