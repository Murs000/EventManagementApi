using EventManagementApi.Core.Application.Features.Queries.Venue.ViewModels;
using MediatR;

namespace EventManagementApi.Core.Application.Features.Queries.Venue.GetById;

public class GetVenueByIdQuery : IRequest<PlaceDto>
{
    public int Id { get; set; }
}