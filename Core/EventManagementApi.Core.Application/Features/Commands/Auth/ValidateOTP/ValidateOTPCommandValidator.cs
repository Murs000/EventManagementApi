using FluentValidation;

namespace EventManagementApi.Core.Application.Features.Commands.Auth.ValidateOTP;

public class ValidateOTPCommandValidator : AbstractValidator<ValidateOTPCommand>
{
    public ValidateOTPCommandValidator()
    {
        RuleFor(x => x.OTP).NotEmpty();
    }
}