using Domain.Core.Events;

namespace In.Bus;

public interface IMediatorHandler
{
// interface    Task SendCommand<T>(T command)
//         where T : Command;

    Task RaiseEvent<T>(T @event)
        where T : Event;
}
