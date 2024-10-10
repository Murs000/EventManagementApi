using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using EventManagementApi.Infrastructure.Persistence.DataAccess;

namespace EventManagementApi.Infrastructure.Persistence.Repositories;

public class EventRepository : Repository<Event> , IEventRepository
{
    public EventRepository(EventAppDB context) : base(context)
    {
    }
}