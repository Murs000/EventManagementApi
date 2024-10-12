using EventManagementApi.Core.Domain.Common;
using EventManagementApi.Core.Domain.Enums;

namespace EventManagementApi.Core.Domain.Entities;

public class Venue : BaseEntity<Venue>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Seat> Seats { get; set;}
    public List<Event> Events { get; set;}
}