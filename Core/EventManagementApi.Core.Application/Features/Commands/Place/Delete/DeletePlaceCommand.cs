using MediatR;

namespace EventManagementApi.Core.Application.Features.Commands.Place.Delete;

public class DeletePlaceCommand : IRequest<bool>
{
    public int Id { get; set; }
}