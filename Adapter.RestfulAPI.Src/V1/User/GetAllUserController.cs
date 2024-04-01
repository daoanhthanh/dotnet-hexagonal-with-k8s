using Adapter.RestfulAPI.Src.V1.User.Base;
using In.Bus;
using In.Notification;
using In.User;
using In.User.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.RestfulAPI.Src.V1.User;

public class GetAllUserController(
    // INotificationHandler<DomainNotificationDTO> notifications,
    // IMediatorHandler mediator,
    GetAllUser getAllUser)
    : UserV1Controller(
        // notifications, mediator
        )
{
    [HttpGet]
    public IEnumerable<UserViewModel> Get()
    {
        var result = getAllUser.Get();
        
        return result;
        // return Response(_getAllUser.Get());
    }
}