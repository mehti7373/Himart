using MediatR;

namespace Core.Application.Tasks.Commands.CreateTask;
public record CreateTaskCommand(string title, Enums.TaskEntityStatus Status, DateOnly? checkoutDate, Guid creatorUserId)
    : IRequest<CreateTaskCommandResponse>;
public record CreateTaskCommandResponse(Guid id);
