using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using EventManagementApi.Infrastructure.Persistence.DataAccess;

namespace EventManagementApi.Infrastructure.Persistence.Repositories;

public class UserRepository : Repository<User> , IUserRepository
{
    public UserRepository(EventAppDB context) : base(context)
    {
    }
}