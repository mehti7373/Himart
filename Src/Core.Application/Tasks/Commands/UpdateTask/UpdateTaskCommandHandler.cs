using Core.Application.Tasks.Exceptions;
using Core.Domain.TaskAggregate;
using Core.Domain.TaskAggregate.ValueObjects;
using Framework.Ef;
using MediatR;

namespace Core.Application.Tasks.Commands.UpdateTask;

public class UpdateTaskCommandHandler(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateTaskCommand, UpdateTaskCommandResponse>
{

    public async Task<UpdateTaskCommandResponse> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var taskEntity = await taskRepository.FindAsync(request.id) ?? throw TaskEntityNotFoundException.Create();

        var title = Title.Parse(request.title);
        var status = Status.FromValue((int)request.Status);
        CheckOutDate? checkOutDate = request.checkoutDate == null ? null : CheckOutDate.Parse(request.checkoutDate.Value);

        taskEntity.Set(title, status, checkOutDate);
        await taskRepository.UpdateAsync(taskEntity);
        await unitOfWork.SaveChangesAsync();
        return new(taskEntity.Id);
    }
}
