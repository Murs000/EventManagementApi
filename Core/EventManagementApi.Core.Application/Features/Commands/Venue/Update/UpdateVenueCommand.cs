using MediatR;

namespace EventManagementApi.Core.Application.Features.Commands.Venue.Update;

public class UpdateVenueCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}