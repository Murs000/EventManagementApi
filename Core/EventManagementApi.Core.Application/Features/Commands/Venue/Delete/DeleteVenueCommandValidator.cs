using FluentValidation;

namespace EventManagementApi.Core.Application.Features.Commands.Venue.Delete
{
    public class UpdateVenueCommandValidator : AbstractValidator<DeleteVenueCommand>
    {
        public UpdateVenueCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Valid Place ID is required");
        }
    }
}