using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Core.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EventManagementApi.Core.Application.Features.Commands.Venue.Update;

public class UpdateVenueCommandHandler : IRequestHandler<UpdateVenueCommand, bool>
{
    private readonly IVenueRepository _venueRepository;
    private readonly IUserManager _userManager;

    public UpdateVenueCommandHandler(IVenueRepository venueRepository, IUserManager userManager)
    {
        _venueRepository = venueRepository;
        _userManager = userManager;
    }

    public async Task<bool> Handle(UpdateVenueCommand request, CancellationToken cancellationToken)
    {
        var userId = _userManager.GetCurrentUserId();
        var place = await _venueRepository.GetAsync(q => q.Id == request.Id);

        if (place == null)
        {
            return false; // Handle not found
        }

        place.Name = request.Name;
        place.Address = request.Address;
        
        place.SetModifyCredentials(userId);

        _venueRepository.Update(place);
        await _venueRepository.SaveAsync();

        return true;
    }
}