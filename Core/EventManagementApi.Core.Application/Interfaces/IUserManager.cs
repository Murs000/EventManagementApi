using EventManagementApi.Core.Domain.Entities;

namespace EventManagementApi.Core.Application.Interfaces;

public interface IUserManager
{
    public int GetCurrentUserId();
    (string token,DateTime expireAt) GenerateTJwtToken(User user);
}
