using MediatR;

namespace EventManagementApi.Core.Application.Features.Commands.Venue.Delete;

public class DeleteVenueCommand : IRequest<bool>
{
    public int Id { get; set; }
}