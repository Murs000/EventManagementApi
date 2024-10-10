using EventManagementApi.Core.Application.Features.Queries.Place.ViewModels;
using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EventManagementApi.Core.Application.Features.Queries.Place.GetById;

public class GetPlaceByIdQueryHandler : IRequestHandler<GetPlaceByIdQuery, PlaceDto>
{
    private readonly IPlaceRepository _placeRepository;

    public GetPlaceByIdQueryHandler(IPlaceRepository placeRepository)
    {
        _placeRepository = placeRepository;
    }

    public async Task<PlaceDto> Handle(GetPlaceByIdQuery request, CancellationToken cancellationToken)
    {
        var place = await _placeRepository.GetAsync(q => q.Id == request.Id);

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