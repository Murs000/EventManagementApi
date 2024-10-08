using System.Security.Claims;
using EventManagementApi.Core.Domain.Entities;

namespace EventManagementApi.Core.Application.Interfaces;

public interface IClaimManager
{
    int GetCurrentUserId();
    IEnumerable<Claim> GetUserClaims(User user);
}
