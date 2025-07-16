using MediatR;

namespace Core.Application.Tasks.Commands.CreateTask;
public record CreateTaskCommand(string title, TaskStatus Status, DateOnly checkoutDate) : IRequest<CreateTaskCommandResponse>;
public record CreateTaskCommandResponse();
public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskCommandResponse>
{
    public Task<CreateTaskCommandResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
