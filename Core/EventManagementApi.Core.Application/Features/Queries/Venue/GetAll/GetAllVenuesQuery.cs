using EventManagementApi.Core.Application.Features.Queries.Venue.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace EventManagementApi.Core.Application.Features.Queries.Venue.GetAll;

public class GetAllVenuesQuery : IRequest<List<PlaceDto>>
{
}