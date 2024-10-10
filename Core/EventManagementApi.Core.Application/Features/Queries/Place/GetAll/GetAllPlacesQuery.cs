using EventManagementApi.Core.Application.Features.Queries.Place.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace EventManagementApi.Core.Application.Features.Queries.Place.GetAll;

public class GetAllPlacesQuery : IRequest<List<PlaceDto>>
{
}