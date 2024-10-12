using EventManagementApi.Core.Application.Features.Commands.Venue.Create;
using EventManagementApi.Core.Application.Features.Commands.Venue.Delete;
using EventManagementApi.Core.Application.Features.Commands.Venue.Update;
using EventManagementApi.Core.Application.Features.Queries.Venue.GetAll;
using EventManagementApi.Core.Application.Features.Queries.Venue.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class VenueController(IMediator mediator) : ControllerBase
{
    [HttpGet("venues")]
    public async Task<IActionResult> GetPleaces()
    {
        return Ok(await mediator.Send(new GetAllVenuesQuery()));
    }
    [HttpGet("venue")]
    public async Task<IActionResult> GetPlace(int id)
    {
        return Ok(await mediator.Send(new GetVenueByIdQuery{ Id = id}));
    }
    [HttpPost("create-venue")]
    public async Task<IActionResult> CreatePlace(CreateVenueCommand command)
    {
        return Ok(await mediator.Send(command));
    }
    [HttpPut("update-venue")]
    public async Task<IActionResult> UpdatePlace(UpdateVenueCommand command)
    {
        return Ok(await mediator.Send(command));
    }
    [HttpDelete("delete-venue")]
    public async Task<IActionResult> DeletePlace(DeleteVenueCommand command)
    {
        return Ok(await mediator.Send(command));
    }
}