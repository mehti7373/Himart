using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Tasks.IntegerationEvents;

public record TaskStatusUpdatedEvent
{
    public Guid EventId { get; private set; }
    public Guid TaskId { get; private set; }
    public string Status { get; private set; }

    public TaskStatusUpdatedEvent(Guid taskId, string status)
    {
        EventId = Guid.NewGuid();
        TaskId = taskId;
        Status = status;
    }
}
