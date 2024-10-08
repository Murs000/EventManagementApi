using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    [HttpPost("log-in")]
    public async Task<IActionResult> LogIn()
    {
        return Ok();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register()
    {
        return Ok();
    }

    [HttpPost("confirm-email")]
    public async Task<IActionResult> ConfirmEmail()
    {
        return Ok();
    }

    [HttpPost("confirm-otp")]
    public async Task<IActionResult> ConfirmPasswordOTP()
    {
        return Ok();
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken()
    {
        return Ok();
    }

    [HttpPost("forget-password")]
    public async Task<IActionResult> ForgetPassword()
    {
        return Ok();
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword()
    {
        return Ok();
    }
}