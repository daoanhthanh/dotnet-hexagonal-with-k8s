using Application.Domain.Core.Notifications;
using MediatR;

namespace Application.Ports.In.Notification;

public class DomainNotificationDTO(string key, string value) : DomainNotification(key, value), INotification;