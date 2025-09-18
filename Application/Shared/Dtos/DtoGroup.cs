using Application.Dtos.Core;
using Application.Shared.Dtos.Interface;

namespace Application.Shared.Dtos;

public class DtoGroup : IDtoGroup
{
    public required IBaseDto Dto { get; set; }
    public required IUpdateDto UpdateDto { get; set; }
    public required IAddDto InsertDto { get; set; }
}