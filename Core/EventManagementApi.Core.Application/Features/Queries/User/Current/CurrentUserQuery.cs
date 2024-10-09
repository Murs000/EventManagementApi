using EventManagementApi.Core.Application.Features.Queries.User.ViewModels;
using MediatR;

namespace EventManagementApi.Core.Application.Features.Queries.User.Current;

public class CurrentUserQuery : IRequest<UserDto>
{
}