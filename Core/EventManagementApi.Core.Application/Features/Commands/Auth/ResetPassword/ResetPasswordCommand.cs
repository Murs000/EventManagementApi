using MediatR;

namespace EventManagementApi.Core.Application.Features.Commands.Auth.ResetPassword;

public class ResetPasswordCommand : IRequest<bool>
{
    public string Email { get; set; }
    public string NewPassword { get; set; }
}