using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class EventController(IMediator mediator) : ControllerBase
{
    [HttpGet("events")]
    public async Task<IActionResult> GetEvents()
    {
        return Ok();
    }
    [HttpGet("event")]
    public async Task<IActionResult> GetEvent()
    {
        return Ok();
    }
    [HttpPost("create-event")]
    public async Task<IActionResult> CreateEvent()
    {
        return Ok();
    }
    [HttpPut("update-event")]
    public async Task<IActionResult> UpdateEvent()
    {
        return Ok();
    }
    [HttpDelete("delete-event")]
    public async Task<IActionResult> DeleteEvent()
    {
        return Ok();
    }
}