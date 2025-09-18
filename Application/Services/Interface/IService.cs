using System.Linq.Expressions;
using Application.Dtos;
using Domain.Models;

namespace Application.Services.Interface;

public interface IService<TEntity, TDto, in TInsert, in TUpdate> 
    where TEntity: BaseModel
    where TDto: class, IBaseDto
{
    Task<TDto?> Get(long id);
    Task<IEnumerable<TDto>> Get();
    Task<IEnumerable<TDto>> Get(Expression<Func<TEntity, bool>> predicate);
    Task<TDto> Add(TInsert addRequest);
    Task<TDto?> Update(TUpdate updateRequest);
    Task<bool> Delete(long id);
}