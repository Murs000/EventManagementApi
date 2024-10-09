using EventManagementApi.Core.Domain.Enums;
using MediatR;

namespace EventManagementApi.Core.Application.Features.Commands.User.Update;

public class UpdateUserCommand : IRequest<bool>
{
    public string Name { get; set; }
    public string Surname { get; set; }
}