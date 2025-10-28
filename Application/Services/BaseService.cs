using System.Linq.Expressions;
using Application.Dtos.Core;
using Application.Repository;
using Application.Services.Interface;
using Application.Shared.Mappers.Interface;
using Domain.Models;

namespace Application.Services;

public abstract class BaseService<TEntity, TDto, TInsert, TUpdate>(IRepository<TEntity> repository, 
    IMapper<TEntity, TDto, TInsert, TUpdate> mapper)
    : IService<TEntity, TDto, TInsert, TUpdate>
    where TEntity : BaseModel
    where TDto : class, IBaseDto
    where TInsert : class, IAddDto
    where TUpdate : class, IUpdateDto
{

    public virtual async Task<TDto?> Get(long id)
    {
         var result = await repository.Get(id);
         return result == null ? null : mapper.ToDto(result);
    }

    public virtual async Task<IEnumerable<TDto>> Get()
    {
        var result = await repository.GetAll();

        return result.Select(mapper.ToDto);
    }

    public virtual async Task<IEnumerable<TDto>> Get(Expression<Func<TEntity, bool>> predicate)
    {
        var result = await repository.Search(predicate);

        return result.Select(mapper.ToDto);
    }

    public virtual async Task<TDto> Add(TInsert addRequest)
    {
        var customer = mapper.ToModel(addRequest);
        await repository.Add(customer);
        await repository.Save();
        
        return mapper.ToDto(customer);
    }

    public virtual async Task<TDto?> Update(TUpdate updateRequest)
    {
        var model = await repository.Get(updateRequest.Id);
        if (model == null)
            return null;
        
        model = mapper.ToModel(model, updateRequest);
        repository.Update(model);
        await repository.Save();
        return mapper.ToDto(model);
    }

    public async Task<bool> Delete(long id)
    {
        try
        {
            var modelToDelete = await repository.Get(id);
            if (modelToDelete == null) 
                return false;
            
            repository.Delete(modelToDelete);
            await repository.Save();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}