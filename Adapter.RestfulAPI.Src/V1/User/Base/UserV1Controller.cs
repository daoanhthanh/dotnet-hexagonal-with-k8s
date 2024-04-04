using Adapter.RestfulAPI.Src.Base;
using Application.Ports.In.Bus;
using Application.Ports.In.Notification;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.RestfulAPI.Src.V1.User.Base;

// [Authorize]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/users")]
[Produces("application/json")]
public abstract class UserV1Controller(
    // INotificationHandler<DomainNotificationDTO> notifications,
    // IMediatorHandler mediator
) : RestfulControllerBase(
    // notifications, mediator
    );