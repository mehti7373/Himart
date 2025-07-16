using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Tasks.IntegerationEvents;
using Core.Domain.TaskAggregate.Events;
using MassTransit;
using MediatR;

namespace Core.Application.Tasks.EventHanlders;
public class TaskEntityUpdatedEventHanlder(IBus bus) : INotificationHandler<TaskEntityUpdatedEvent>
{
    public async Task Handle(TaskEntityUpdatedEvent notification, CancellationToken cancellationToken)
    {
        var @event = new TaskStatusUpdatedEvent(notification.Id, notification.Status.Name);
        await bus.Send(@event);
    }
}
