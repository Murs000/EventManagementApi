using System.Security.Cryptography;
using EventManagementApi.Core.Application.Exceptions;
using EventManagementApi.Core.Application.Features.Commands.Auth.ViewModels;
using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Infrastructure.External.Helpers;
using MediatR;

namespace EventManagementApi.Core.Application.Features.Commands.Auth.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, JwtTokenDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserManager _userManager;
    public LoginCommandHandler(IUserRepository userRepository, IUserManager userManager)
    {
        _userRepository = userRepository;
        _userManager = userManager;
    }

    public async Task<JwtTokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(x => x.Username.ToLower() == request.Username.ToLower());

        if (user == null
            || !PasswordHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt)
            || !user.IsActivated)
        {
            throw new UnAuthorizedException("Invalid credentials");
        }

        var refreshToken = RefreshTokenHelper.GenerateRefreshToken(user.Id);
        var refreshExpireAt = DateTime.UtcNow.AddHours(4).AddDays(20);

        user.SetRefreshToken(refreshToken, refreshExpireAt);

        (string token, DateTime expireAt) = _userManager.GenerateTJwtToken(user);
        
        await _userRepository.SaveAsync();

        return new JwtTokenDto
        {
            Token = token,
            TokenExpireAt = expireAt,
            RefreshToken = refreshToken,
            RefreshExpireAt = DateTime.UtcNow.AddHours(4).AddDays(20)
        };
    }
}