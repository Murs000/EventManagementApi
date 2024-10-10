using EventManagementApi.Core.Application.Features.Queries.Place.ViewModels;
using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventManagementApi.Core.Application.Features.Queries.Place.GetAll;

public class GetAllPlacesQueryHandler : IRequestHandler<GetAllPlacesQuery, List<PlaceDto>>
{
    private readonly IPlaceRepository _placeRepository;

    public GetAllPlacesQueryHandler(IPlaceRepository placeRepository)
    {
        _placeRepository = placeRepository;
    }

    public async Task<List<PlaceDto>> Handle(GetAllPlacesQuery request, CancellationToken cancellationToken)
    {
        var places = await _placeRepository.GetAllAsync();

        return places.Select(place => new PlaceDto
        {
            Id = place.Id,
            Name = place.Name,
            Address = place.Address
        }).ToList();
    }
}