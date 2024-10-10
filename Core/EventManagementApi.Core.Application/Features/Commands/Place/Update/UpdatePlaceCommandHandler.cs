using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EventManagementApi.Core.Application.Features.Commands.Place.Update;

public class UpdatePlaceCommandHandler : IRequestHandler<UpdatePlaceCommand, bool>
{
    private readonly IPlaceRepository _placeRepository;
    private readonly IUserManager _userManager;

    public UpdatePlaceCommandHandler(IPlaceRepository placeRepository, IUserManager userManager)
    {
        _placeRepository = placeRepository;
        _userManager = userManager;
    }

    public async Task<bool> Handle(UpdatePlaceCommand request, CancellationToken cancellationToken)
    {
        var userId = _userManager.GetCurrentUserId();
        var place = await _placeRepository.GetAsync(q => q.Id == request.Id);

        if (place == null)
        {
            return false; // Handle not found
        }

        place.Name = request.Name;
        place.Address = request.Address;
        
        place.SetModifyCredentials(userId);

        _placeRepository.Update(place);
        await _placeRepository.SaveAsync();

        return true;
    }
}