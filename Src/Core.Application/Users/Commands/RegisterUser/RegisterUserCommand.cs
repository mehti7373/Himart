using MediatR;

namespace Core.Application.Users.Commands.RegisterUser;

public record RegisterUserCommand(string username, string email, string password)
    : IRequest<RegisterUserCommandResponse>;
public record RegisterUserCommandResponse();

