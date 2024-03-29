using AutoMapper;
using AutoMapper.QueryableExtensions;
using In.User.DTOs;
using DomainModel = Domain.Core.User.Models;

namespace In.User;

public abstract class GetAllUser : IEntityMapper
{
    public abstract IMapper Mapper { get; }


    protected abstract IQueryable<DomainModel.User> GetAll();

    public IEnumerable<UserViewModel> Get()
    {
        return GetAll().ProjectTo<UserViewModel>(Mapper.ConfigurationProvider);
    }
}