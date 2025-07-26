using Application.Dtos;
using Domain.Models;

namespace Application.Shared.Mappers.Interface;

public interface IMapper<TModel, TDto, in TInsert, in TUpdate>
    where TModel : BaseModel
    where TDto : class, IBaseDto
{
    TModel ToModel(TDto dto);
    TModel ToModel(TInsert dto);
    TModel ToModel(TModel model, TUpdate dto);
    TDto ToDto(TModel model);
}