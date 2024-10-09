using MediatR;
using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Application.Exceptions;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using EventManagementApi.Core.Application.Features.Queries.User.ViewModels;

namespace EventManagementApi.Core.Application.Features.Queries.User.Current;

public class CurrentUserQueryHandler : IRequestHandler<CurrentUserQuery, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserManager _userManager;

    public CurrentUserQueryHandler(IUserRepository userRepository, IUserManager userManager)
    {
        _userRepository = userRepository;
        _userManager = userManager;
    }

    public async Task<UserDto> Handle(CurrentUserQuery request, CancellationToken cancellationToken)
    {
        // Extract email or user ID from the token (claims)
        var userId = _userManager.GetCurrentUserId();
        var user = await _userRepository.GetAsync(u => u.Id == userId);

        if (user == null)
        {
            throw new NotFoundException("User not found.");
        }

        // Map entity to DTO
        var userDto = new UserDto
        {
            Username = user.Username,
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email
        };

        return userDto;
    }
}