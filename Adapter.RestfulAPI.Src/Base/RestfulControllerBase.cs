using Application.Ports.In.Bus;
using Application.Ports.In.Notification;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.RestfulAPI.Src.Base;

[ApiController]
public class RestfulControllerBase : ControllerBase
{
    // private readonly DomainNotificationHandler _notifications;
    // private readonly IMediatorHandler _mediator;
    //
    // protected RestfulControllerBase(
    //     INotificationHandler<DomainNotificationDTO> notifications,
    //     IMediatorHandler mediator)
    // {
    //     _notifications = (DomainNotificationHandler)notifications;
    //     _mediator = mediator;
    // }

    // protected IEnumerable<DomainNotificationDTO> Notifications => _notifications.GetNotifications();
    //
    // protected bool IsValidOperation()
    // {
    //     return !_notifications.HasNotifications();
    // }
    //
    // protected new IActionResult Response(object result = null)
    // {
    //     if (IsValidOperation())
    //     {
    //         return Ok(new
    //         {
    //             success = true,
    //             data = result,
    //         });
    //     }
    //
    //     return BadRequest(new
    //     {
    //         success = false,
    //         errors = _notifications.GetNotifications().Select(n => n.Value),
    //     });
    // }

    // protected void NotifyModelStateErrors()
    // {
    //     var errors = ModelState.Values.SelectMany(v => v.Errors);
    //     foreach (var err in errors)
    //     {
    //         var errMsg = err.Exception == null ? err.ErrorMessage : err.Exception.Message;
    //         NotifyError(string.Empty, errMsg);
    //     }
    // }

    // protected void NotifyError(string code, string message)
    // {
    //     _mediator.RaiseEvent(new DomainNotificationDTO(code, message));
    // }

    // protected void AddIdentityErrors(IdentityResult result)
    // {
    //     foreach (var error in result.Errors)
    //     {
    //         NotifyError(result.ToString(), error.Description);
    //     }
    // }
    //
    /// <summary>
    /// Create a proper response for client, based on the response object
    /// </summary>
    // protected ObjectResult Handle([ActionResultObjectValue] object response)
    // {
    //     var responseError = new ApiResponse(false);
    //
    //     switch (response)
    //     {
    //         case BaseException e:
    //             // var responseError = new ApiResponse(false)
    //             responseError.ErrorCode = e.ErrorCode;
    //             responseError.ErrorMessage = e.Message;
    //
    //             return new ObjectResult(responseError)
    //             {
    //                 StatusCode = e.HTTPStatusCode,
    //             };
    //         case Exception ex:
    //
    //             Console.WriteLine("\nMessage ---\n{0}", ex.Message);
    //             Console.WriteLine(
    //                 "\nHelpLink ---\n{0}", ex.HelpLink);
    //             Console.WriteLine("\nSource ---\n{0}", ex.Source);
    //             Console.WriteLine(
    //                 "\nStackTrace ---\n{0}", ex.StackTrace);
    //             Console.WriteLine(
    //                 "\nTargetSite ---\n{0}", ex.TargetSite);
    //
    //             responseError.ErrorCode = "INTERNAL_ERROR";
    //             responseError.ErrorMessage = "Internal Server Error";
    //             return new ObjectResult(responseError)
    //             {
    //                 StatusCode = 500
    //             };
    //         default:
    //             return new OkObjectResult(response);
    //     }
    // }
    //
    // public override OkObjectResult Ok([ActionResultObjectValue] object? value)
    // {
    //     if (value != null) return base.Ok(new ApiResponse(value));
    //     return base.Ok(new ApiResponse(true));
    // }
}