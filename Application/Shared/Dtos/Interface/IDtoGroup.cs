using Application.Dtos;
using Application.Dtos.Core;

namespace Application.Shared.Dtos.Interface;

public interface IDtoGroup
{
    IBaseDto Dto { get; }
    IUpdateDto UpdateDto { get; }
    IAddDto InsertDto { get; }
}