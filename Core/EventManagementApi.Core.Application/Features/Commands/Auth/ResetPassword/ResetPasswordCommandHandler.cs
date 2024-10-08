using EventManagementApi.Core.Application.Exceptions;
using EventManagementApi.Core.Application.Interfaces;
using EventManagementApi.Infrastructure.External.Helpers;
using MediatR;

namespace EventManagementApi.Core.Application.Features.Commands.Auth.ResetPassword;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public ResetPasswordCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(x => x.Email == request.Email && x.OTPExpireDate > DateTime.Now);

        if (user == null)
        {
            throw new NotFoundException("Email not found or Too Late.");
        }

        var (hash, salt) = PasswordHelper.HashPassword(request.NewPassword);

        user.SetPassword(hash, salt);
        user.ResetOtp();

        await _userRepository.SaveAsync();

        return true;
    }
}