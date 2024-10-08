using MediatR;

namespace EventManagementApi.Core.Application.Features.Commands.Auth.ValidateOTP;

public class ValidateOTPCommand : IRequest<bool>
{
    public string OTP { get; set; }
}