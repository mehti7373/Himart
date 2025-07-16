using Core.Domain.Shared.ValueObjects;
using Core.Domain.TaskAggregate;
using Core.Domain.TaskAggregate.DomainService;
using Core.Domain.TaskAggregate.Entities;
using Core.Domain.TaskAggregate.ValueObjects;
using Framework.Domain.Exceptions;
using Framework.Ef;
using MediatR;

namespace Core.Application.Tasks.Commands.CreateTask;

public class CreateTaskCommandHandler(ITaskRepository taskRepository, ITaskDomainService taskDomainService, IUnitOfWork unitOfWork) : IRequestHandler<CreateTaskCommand, CreateTaskCommandResponse>
{
    public async Task<CreateTaskCommandResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var title = Title.Parse(request.title);
        var status = Status.FromValue((int)request.Status);
        CheckOutDate? checkOutDate = request.checkoutDate == null ? null : CheckOutDate.Parse(request.checkoutDate.Value);
        var creatorUserId = CreatorUserId.Parse(request.creatorUserId);

        if (taskDomainService.IsValidCheckoutDate(CreateAt.Now, checkOutDate) == false)
        {
            //custome exception
            throw new FrameworkException("InValidCheckoutDate");
        }

        var taskEntity = new TaskEntity(title, status, checkOutDate, creatorUserId);
        await taskRepository.AddAsync(taskEntity);
        await unitOfWork.SaveChangesAsync();

        return new(taskEntity.Id);
    }
}
