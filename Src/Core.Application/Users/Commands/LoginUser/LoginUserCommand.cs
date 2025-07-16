using MediatR;

namespace Core.Application.Users.Commands.LoginUser;

public record LoginUserCommand(string username, string password) : IRequest<LoginUserCommandResponse>;
public record LoginUserCommandResponse();
