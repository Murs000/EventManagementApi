using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using EventManagementApi.Infrastructure.Persistence.DataAccess;

namespace EventManagementApi.Infrastructure.Persistence.Repositories;

public class PlaceRepository : Repository<Place> , IPlaceRepository
{
    public PlaceRepository(EventAppDB context) : base(context)
    {
    }
}