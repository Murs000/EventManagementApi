using MediatR;

namespace EventManagementApi.Core.Application.Features.Commands.Auth.ConfirmEmail;

public class ConfirmEmailCommand : IRequest<bool>
{
    public string Email { get; set; }
    public string OTP { get; set; }
}
