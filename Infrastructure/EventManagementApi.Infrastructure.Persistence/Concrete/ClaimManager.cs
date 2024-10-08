using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Authentication;
using System.Security.Claims;

namespace EventManagementApi.Infrastructure.Persistence.Concrete;

public class ClaimManager : IClaimManager
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ClaimManager(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetCurrentUserId()
    {
        var claim = GetUserClaim(ClaimTypes.NameIdentifier);
        if (!int.TryParse(claim.Value, out var currentUserId))
            throw new AuthenticationException("Can't parse claim value");
        return currentUserId;
    }

    public IEnumerable<Claim> GetUserClaims(User user)
    {
        return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
    }

    public Claim GetUserClaim(string claimType)
    {
        var user = _httpContextAccessor.HttpContext.User;

        if (!user.Identity.IsAuthenticated)
            throw new AuthenticationException("User is not authenticated");

        var claim = user.FindFirst(claimType);

        if (claim == null)
            throw new AuthenticationException("User does not have required claim");

        return claim;
    }
}