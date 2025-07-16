using Core.Domain.Shared.ValueObjects;
using Core.Domain.TaskAggregate.Events;
using Core.Domain.TaskAggregate.ValueObjects;
using Framework.Domain.Models;

namespace Core.Domain.TaskAggregate.Entities;
public class TaskEntity : AggregateRoot<TaskEntity, Guid>
{
    public Title Title { get; private set; }
    public Status Status { get; private set; }
    public CreateAt CreateAt { get; private set; }
    public CheckOutDate? CheckOutDate { get; private set; }
    public CreatorUserId CreatorUserId { get; set; }

    private TaskEntity()
    {
    }

    public TaskEntity(Title title, Status status, CheckOutDate? checkOutDate,CreatorUserId creatorUserId)
    {
        Title = title;
        Status = status;
        CheckOutDate = checkOutDate;
        CreatorUserId = creatorUserId;
        CreateAt = CreateAt.Now;
        AddDomainEvent(new TaskEntityCreatedEvent(Title,
                                                  Status,
                                                  CheckOutDate,
                                                  CreateAt,
                                                  CreatorUserId));
    }

    public void Set(Title title,Status status, CheckOutDate? checkOutDate)
    {
        Title = title;
        Status = status;
        CheckOutDate = checkOutDate;

        AddDomainEvent(new TaskEntityUpdatedEvent(Id,Title, Status, CheckOutDate));
    }
}
