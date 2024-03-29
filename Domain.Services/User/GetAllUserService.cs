using AutoMapper;
using Domain.Core.User;
using In.User;

namespace Domain.Services.User;

public class GetAllUserService(
    IMapper mapper,
    IUserRepository userRepo) : GetAllUser
{
    public override IMapper Mapper { get; } = mapper;

    protected override IQueryable<Core.User.Models.User> GetAll()
    {
       return userRepo.GetAll();
    }
}