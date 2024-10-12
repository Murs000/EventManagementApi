using MediatR;

namespace EventManagementApi.Core.Application.Features.Commands.Venue.Create;

public class CreateVenueCommand : IRequest<int> // Returns the newly created Venue ID
{
    public string Name { get; set; }
    public string Address { get; set; }
}