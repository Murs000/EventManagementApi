using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using EventManagementApi.Infrastructure.Persistence.DataAccess;

namespace EventManagementApi.Infrastructure.Persistence.Repositories;

public class SeatRepository : Repository<Seat> , ISeatRepository
{
    public SeatRepository(EventAppDB context) : base(context)
    {
    }
}