using EventManagementApi.Core.Domain.Common;
using EventManagementApi.Core.Domain.Enums;

namespace EventManagementApi.Core.Domain.Entities;

public class Seat : BaseEntity<Seat>
{
    public int Row { get; set; }
    public int NumberOfSeats { get; set; }
    public decimal Price { get; set; }

    public int PlaceId { get; set; }
    public Venue Place { get; set; }
}