using EventManagementApi.Core.Domain.Common;
using EventManagementApi.Core.Domain.Enums;

namespace EventManagementApi.Core.Domain.Entities;

public class Event : BaseEntity<Event>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string StartDate { get; set; }

    public int VenueId { get; set; }
    public Venue Venue { get; set; }
}