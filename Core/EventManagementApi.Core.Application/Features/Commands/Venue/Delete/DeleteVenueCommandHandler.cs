using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EventManagementApi.Core.Application.Features.Commands.Venue.Delete;

public class DeleteVenueCommandHandler : IRequestHandler<DeleteVenueCommand, bool>
{
    private readonly IVenueRepository _placeRepository;

    public DeleteVenueCommandHandler(IVenueRepository placeRepository)
    {
        _placeRepository = placeRepository;
    }

    public async Task<bool> Handle(DeleteVenueCommand request, CancellationToken cancellationToken)
    {
        var place = await _placeRepository.GetAsync(q => q.Id == request.Id);

        if (place == null)
        {
            return false; // Handle not found
        }

        _placeRepository.SoftDelete(place);
        await _placeRepository.SaveAsync();

        return true;
    }
}