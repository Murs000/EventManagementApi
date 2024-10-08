using MediatR;

namespace EventManagementApi.Core.Application.Features.Commands.Auth.Register;

public class RegisterCommand : IRequest<bool>
{
    public string Username { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
