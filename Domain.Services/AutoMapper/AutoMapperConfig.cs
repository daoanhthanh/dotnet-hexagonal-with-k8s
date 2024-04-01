using AutoMapper;
using DomainModel = Domain.Core.User.Models;
using In.User.DTOs;

namespace Domain.Services.AutoMapper;

// TODO: Không được SOLID cho lắm, tuy nhiên file này không cần chỉnh sửa nhiều,
// nên để tạm như vậy
public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateModelsToViewModels();
        CreateViewModelsToModels();
    }

    private void CreateModelsToViewModels()
    {
        CreateMap<DomainModel.User, UserViewModel>()
            .ForMember(domainUser =>
                    domainUser.Id,
                opt =>
                    opt.MapFrom(userViewModel => userViewModel.Id.Value.ToString())
            );
    }

    private void CreateViewModelsToModels()
    {
        CreateMap<UserViewModel, DomainModel.User>();
    }
}