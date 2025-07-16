using Core.Application.Tasks.Commands.CreateTask;
using Endpoint.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers;


[ApiController]
[Route("[controller]")]
public class TaskController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<CreateTaskCommandResponse> Create(CreateTaskViewModel model)
    {
        var currentUserId = Guid.Empty;// todo get from httpcontext
        CreateTaskCommand command = new(model.title, model.Status, model.checkoutDate, currentUserId);
        var response = await sender.Send(command);
        return response;
    }
}
