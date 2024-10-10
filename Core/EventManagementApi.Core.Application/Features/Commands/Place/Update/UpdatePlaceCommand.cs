using MediatR;

namespace EventManagementApi.Core.Application.Features.Commands.Place.Update;

public class UpdatePlaceCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}