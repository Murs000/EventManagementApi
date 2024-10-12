using EventManagementApi.Core.Application.Features.Queries.Venue.ViewModels;
using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventManagementApi.Core.Application.Features.Queries.Venue.GetAll;

public class GetAllVenuesQueryHandler : IRequestHandler<GetAllVenuesQuery, List<PlaceDto>>
{
    private readonly IVenueRepository _venueRepository;

    public GetAllVenuesQueryHandler(IVenueRepository venueRepository)
    {
        _venueRepository = venueRepository;
    }

    public async Task<List<PlaceDto>> Handle(GetAllVenuesQuery request, CancellationToken cancellationToken)
    {
        var places = await _venueRepository.GetAllAsync();

        return places.Select(place => new PlaceDto
        {
            Id = place.Id,
            Name = place.Name,
            Address = place.Address
        }).ToList();
    }
}