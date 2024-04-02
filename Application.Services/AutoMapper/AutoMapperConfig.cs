using AutoMapper;
using DomainModel = Application.Domain.Core.User.Models;
using Application.Ports.In.User.DTOs;

namespace Application.Services.AutoMapper;

// TODO: Không được SOLID cho lắm, tuy nhiên file này không cần chỉnh sửa nhiều,
// nên để tạm như vậy
public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateModelsToViewModels();
        CreateFormModelsToModels();
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

    private void CreateFormModelsToModels()
    {
        CreateMap<UserViewModel, DomainModel.User>();
    }
}