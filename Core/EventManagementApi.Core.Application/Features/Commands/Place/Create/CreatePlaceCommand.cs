using MediatR;

namespace EventManagementApi.Core.Application.Features.Commands.Place.Create;

public class CreatePlaceCommand : IRequest<int> // Returns the newly created Place ID
{
    public string Name { get; set; }
    public string Address { get; set; }
}