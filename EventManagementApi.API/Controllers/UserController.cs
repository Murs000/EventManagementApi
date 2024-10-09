using EventManagementApi.Core.Application.Features.Commands.User.Update;
using EventManagementApi.Core.Application.Features.Queries.User.Current;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet("current")]
    public async Task<IActionResult> GetCurrentUser()
    {
        return Ok(await mediator.Send(new CurrentUserQuery()));
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
    {
        return Ok(await mediator.Send(command));
    }
}