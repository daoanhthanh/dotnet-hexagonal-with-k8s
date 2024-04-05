using AutoMapper;

namespace Application.Ports.In;

public interface IEntityMapper
{
    public IMapper Mapper { get; }
}