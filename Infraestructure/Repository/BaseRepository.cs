using System.Linq.Expressions;
using Application.Repository;
using Domain.Models;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository;

public abstract class Repository<TEntity>(AddressManagementDbContext dbContext)
    : IRepository<TEntity>
    where TEntity : BaseModel
{
    
    protected readonly DbSet<TEntity> DbSet = dbContext.Set<TEntity>();

    public virtual async Task Add(TEntity model)
    {
        await DbSet.AddAsync(model);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
    {
        IQueryable<TEntity> query = DbSet;
        if (include is not null)
            query = include(query);

        return await query.ToListAsync();
    }

    public virtual async Task<TEntity?> Get(long id, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
    {
        IQueryable<TEntity> query = DbSet;
        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(model => model.Id == id);
    }

    public virtual void Update(TEntity model)
    {
        DbSet.Attach(model);
        DbSet.Entry(model).State = EntityState.Modified;
    }

    public void Delete(TEntity model)
    {
        DbSet.Remove(model);
    }

    public virtual async Task<IEnumerable<TEntity>> Search(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
    {
        IQueryable<TEntity> query = DbSet;
        
        if (include is not null)
            query = include(query);
        
        return await query.Where(predicate).ToListAsync();
    }

    public async Task Save()
    {
        await dbContext.SaveChangesAsync();
    }
}