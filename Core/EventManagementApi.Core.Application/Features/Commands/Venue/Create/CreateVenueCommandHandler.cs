using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EventManagementApi.Core.Application.Features.Commands.Venue.Create;

public class CreateVenueCommandHandler : IRequestHandler<CreateVenueCommand, int>
{
    private readonly IVenueRepository _VenueRepository;
    private readonly IUserManager _userManager;

    public CreateVenueCommandHandler(IVenueRepository VenueRepository, IUserManager userManager)
    {
        _VenueRepository = VenueRepository;
        _userManager = userManager;
    }

    public async Task<int> Handle(CreateVenueCommand request, CancellationToken cancellationToken)
    {
        var userId = _userManager.GetCurrentUserId();
        var newPlace = new Domain.Entities.Venue
        {
            Name = request.Name,
            Address = request.Address
        }.SetCreationCredentials(userId);

        await _VenueRepository.AddAsync(newPlace);
        await _VenueRepository.SaveAsync();

        return newPlace.Id;
    }
}