using System.Linq.Expressions;
using Domain.Models;

namespace Application.Repository;

public interface IRepository<TEntity> where TEntity : BaseModel
{
     Task Add(TEntity model);
     Task<IEnumerable<TEntity>> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);
     Task<TEntity?> Get(long id, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);
     void Update(TEntity model);
     void Delete(TEntity model);
     Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);
     Task Save();
}