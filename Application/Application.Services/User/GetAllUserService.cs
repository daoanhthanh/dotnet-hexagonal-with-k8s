using AutoMapper;
using Application.Domain.Core.User;
using Application.Ports.In.User;

namespace Application.Services.User;

public class GetAllUserService(
    IMapper mapper,
    IUserRepository userRepo) : GetAllUser
{
    public override IMapper Mapper { get; } = mapper;

    protected override IQueryable<Application.Domain.Core.User.Models.User?> GetAll()
    {
       return userRepo.GetAll();
    }
}