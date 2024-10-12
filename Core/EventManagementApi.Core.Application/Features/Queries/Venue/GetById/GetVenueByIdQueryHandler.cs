using EventManagementApi.Core.Application.Features.Queries.Venue.ViewModels;
using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EventManagementApi.Core.Application.Features.Queries.Venue.GetById;

public class GetPlaceByIdQueryHandler : IRequestHandler<GetVenueByIdQuery, PlaceDto>
{
    private readonly IVenueRepository _venueRepository;

    public GetPlaceByIdQueryHandler(IVenueRepository venueRepository)
    {
        _venueRepository = venueRepository;
    }

    public async Task<PlaceDto> Handle(GetVenueByIdQuery request, CancellationToken cancellationToken)
    {
        var place = await _venueRepository.GetAsync(q => q.Id == request.Id);

        if (place == null)
        {
            return null; // Handle not found
        }

        return new PlaceDto
        {
            Id = place.Id,
            Name = place.Name,
            Address = place.Address
        };
    }
}