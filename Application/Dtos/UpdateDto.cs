using Application.Dtos.Core;

namespace Application.Dtos;

public abstract class UpdateDto : IUpdateDto
{
    public long Id { get; set; }
}