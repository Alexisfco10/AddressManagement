using Application.Dtos;
using Domain.Models;

namespace Application.Shared.Mappers.Interface;

public interface IMapper<TEntity, TDto, in TInsert, in TUpdate>
    where TEntity : BaseModel
    where TDto : class, IBaseDto
{
    TEntity ToModel(TDto dto);
    TEntity ToModel(TInsert dto);
    TEntity ToModel(TEntity model, TUpdate dto);
    TDto ToDto(TEntity model);
}