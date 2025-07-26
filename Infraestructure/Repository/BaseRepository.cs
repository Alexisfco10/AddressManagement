using System.Linq.Expressions;
using Application.Repository;
using Domain.Models;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository;

public abstract class Repository<TModel>(AddressManagementDbContext dbContext)
    : IRepository<TModel>
    where TModel : BaseModel
{
    
    protected readonly DbSet<TModel> DbSet = dbContext.Set<TModel>();

    public virtual async Task Add(TModel model)
    {
        await DbSet.AddAsync(model);
    }

    public virtual async Task<IEnumerable<TModel>> GetAll(Func<IQueryable<TModel>, IQueryable<TModel>>? include = null)
    {
        IQueryable<TModel> query = DbSet;
        if (include is not null)
            query = include(query);

        return await query.ToListAsync();
    }

    public virtual async Task<TModel?> Get(long id, Func<IQueryable<TModel>, IQueryable<TModel>>? include = null)
    {
        IQueryable<TModel> query = DbSet;
        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(model => model.Id == id);
    }

    public virtual void Update(TModel model)
    {
        DbSet.Attach(model);
        DbSet.Entry(model).State = EntityState.Modified;
    }

    public void Delete(TModel model)
    {
        DbSet.Remove(model);
    }

    public virtual async Task<IEnumerable<TModel>> Search(
            Expression<Func<TModel, bool>> predicate,
            Func<IQueryable<TModel>, IQueryable<TModel>>? include = null)
    {
        IQueryable<TModel> query = DbSet;
        
        if (include is not null)
            query = include(query);
        
        return await query.Where(predicate).ToListAsync();
    }

    public async Task Save()
    {
        await dbContext.SaveChangesAsync();
    }
}