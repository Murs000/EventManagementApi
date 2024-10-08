using EventManagementApi.Core.Application.Features.Commands.Auth.ViewModels;
using MediatR;

namespace EventManagementApi.Core.Application.Features.Commands.Auth.RefreshToken;

public class RefreshTokenCommand : IRequest<JwtTokenDto>
{
    public string RefreshToken { get; set; }
}