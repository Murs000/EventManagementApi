using FluentValidation;

namespace EventManagementApi.Core.Application.Features.Commands.Auth.RefreshToken;

public class RefreshTokenCommandValidator:AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(command => command.RefreshToken).NotEmpty();
    }
}