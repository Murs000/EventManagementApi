using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EventManagementApi.Core.Application.Features.Commands.Place.Create;

public class CreatePlaceCommandHandler : IRequestHandler<CreatePlaceCommand, int>
{
    private readonly IPlaceRepository _placeRepository;
    private readonly IUserManager _userManager;

    public CreatePlaceCommandHandler(IPlaceRepository placeRepository, IUserManager userManager)
    {
        _placeRepository = placeRepository;
        _userManager = userManager;
    }

    public async Task<int> Handle(CreatePlaceCommand request, CancellationToken cancellationToken)
    {
        var userId = _userManager.GetCurrentUserId();
        var newPlace = new Domain.Entities.Place
        {
            Name = request.Name,
            Address = request.Address
        }.SetCreationCredentials(userId);

        await _placeRepository.AddAsync(newPlace);
        await _placeRepository.SaveAsync();

        return newPlace.Id;
    }
}