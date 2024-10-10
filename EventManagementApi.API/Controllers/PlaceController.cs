using EventManagementApi.Core.Application.Features.Commands.Place.Create;
using EventManagementApi.Core.Application.Features.Commands.Place.Delete;
using EventManagementApi.Core.Application.Features.Commands.Place.Update;
using EventManagementApi.Core.Application.Features.Queries.Place.GetAll;
using EventManagementApi.Core.Application.Features.Queries.Place.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class PlaceController(IMediator mediator) : ControllerBase
{
    [HttpGet("places")]
    public async Task<IActionResult> GetPleaces()
    {
        return Ok(await mediator.Send(new GetAllPlacesQuery()));
    }
    [HttpGet("place")]
    public async Task<IActionResult> GetPlace(int id)
    {
        return Ok(await mediator.Send(new GetPlaceByIdQuery{ Id = id}));
    }
    [HttpPost("create-place")]
    public async Task<IActionResult> CreatePlace(CreatePlaceCommand command)
    {
        return Ok(await mediator.Send(command));
    }
    [HttpPut("update-place")]
    public async Task<IActionResult> UpdatePlace(UpdatePlaceCommand command)
    {
        return Ok(await mediator.Send(command));
    }
    [HttpDelete("delete-place")]
    public async Task<IActionResult> DeletePlace(DeletePlaceCommand command)
    {
        return Ok(await mediator.Send(command));
    }
}