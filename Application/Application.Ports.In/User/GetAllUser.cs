using System.Collections.Generic;
using System.Linq;
using Application.Ports.In.User.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DomainModel = Application.Domain.Core.User.Models;

namespace Application.Ports.In.User;

public abstract class GetAllUser : IEntityMapper
{
    public abstract IMapper Mapper { get; }


    protected abstract IQueryable<DomainModel.User?> GetAll();

    public IEnumerable<UserViewModel> Get()
    {
        return GetAll().ProjectTo<UserViewModel>(Mapper.ConfigurationProvider);
    }
}