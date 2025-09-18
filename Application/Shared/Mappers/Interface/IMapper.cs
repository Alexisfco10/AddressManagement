using Application.Dtos;
using Application.Dtos.Core;
using Domain.Models;

namespace Application.Shared.Mappers.Interface;

public interface IMapper<TEntity, TDto, in TInsert, in TUpdate>
    where TEntity : BaseModel
    where TDto : class, IBaseDto
    where TInsert: class, IAddDto
    where TUpdate: class, IUpdateDto
{
    TEntity ToModel(TDto dto);
    TEntity ToModel(TInsert dto);
    TEntity ToModel(TEntity model, TUpdate dto);
    TDto ToDto(TEntity model);
}