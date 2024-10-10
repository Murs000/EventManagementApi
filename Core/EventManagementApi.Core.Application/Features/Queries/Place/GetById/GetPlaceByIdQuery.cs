using EventManagementApi.Core.Application.Features.Queries.Place.ViewModels;
using MediatR;

namespace EventManagementApi.Core.Application.Features.Queries.Place.GetById;

public class GetPlaceByIdQuery : IRequest<PlaceDto>
{
    public int Id { get; set; }
}