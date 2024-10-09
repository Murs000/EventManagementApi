using EventManagementApi.Core.Application.Features.Commands.Auth.ConfirmEmail;
using EventManagementApi.Core.Application.Features.Commands.Auth.ForgotPassword;
using EventManagementApi.Core.Application.Features.Commands.Auth.Login;
using EventManagementApi.Core.Application.Features.Commands.Auth.RefreshToken;
using EventManagementApi.Core.Application.Features.Commands.Auth.Register;
using EventManagementApi.Core.Application.Features.Commands.Auth.ResetPassword;
using EventManagementApi.Core.Application.Features.Commands.Auth.ValidateOTP;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("log-in")]
    public async Task<IActionResult> LogIn(LoginCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPost("confirm-email")]
    public async Task<IActionResult> ConfirmEmail(ConfirmEmailCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPost("confirm-otp")]
    public async Task<IActionResult> ValidateOtp(ValidateOTPCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(RefreshTokenCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPost("forget-password")]
    public async Task<IActionResult> ForgetPassword(ForgotPasswordCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
    {
        return Ok(await mediator.Send(command));
    }
}