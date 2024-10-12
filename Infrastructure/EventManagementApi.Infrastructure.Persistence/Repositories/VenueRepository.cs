using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using EventManagementApi.Infrastructure.Persistence.DataAccess;

namespace EventManagementApi.Infrastructure.Persistence.Repositories;

public class VenueRepository : Repository<Venue> , IVenueRepository
{
    public VenueRepository(EventAppDB context) : base(context)
    {
    }
}