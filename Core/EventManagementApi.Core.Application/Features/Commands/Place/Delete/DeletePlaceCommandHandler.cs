using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EventManagementApi.Core.Application.Features.Commands.Place.Delete;

public class DeletePlaceCommandHandler : IRequestHandler<DeletePlaceCommand, bool>
{
    private readonly IPlaceRepository _placeRepository;

    public DeletePlaceCommandHandler(IPlaceRepository placeRepository)
    {
        _placeRepository = placeRepository;
    }

    public async Task<bool> Handle(DeletePlaceCommand request, CancellationToken cancellationToken)
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