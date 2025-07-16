using Core.Domain.TaskAggregate.Entities;
using MediatR;

namespace Core.Application.Tasks.Commands.UpdateTask;
public record UpdateTaskCommand(Guid id, string title, Enums.TaskEntityStatus Status, DateOnly? checkoutDate) : IRequest<UpdateTaskCommandResponse>;
public record UpdateTaskCommandResponse(Guid id);
