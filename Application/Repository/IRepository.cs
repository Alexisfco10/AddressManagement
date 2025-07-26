using System.Linq.Expressions;
using Domain.Models;

namespace Application.Repository;

public interface IRepository<TModel> where TModel : BaseModel
{
     Task Add(TModel model);
     Task<IEnumerable<TModel>> GetAll(Func<IQueryable<TModel>, IQueryable<TModel>>? include = null);
     Task<TModel?> Get(long id, Func<IQueryable<TModel>, IQueryable<TModel>>? include = null);
     void Update(TModel model);
     void Delete(TModel model);
     Task<IEnumerable<TModel>> Search(Expression<Func<TModel, bool>> predicate, Func<IQueryable<TModel>, IQueryable<TModel>>? include = null);
     Task Save();
}