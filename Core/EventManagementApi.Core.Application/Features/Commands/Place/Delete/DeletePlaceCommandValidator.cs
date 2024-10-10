using FluentValidation;

namespace EventManagementApi.Core.Application.Features.Commands.Place.Delete
{
    public class UpdatePlaceCommandValidator : AbstractValidator<DeletePlaceCommand>
    {
        public UpdatePlaceCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Valid Place ID is required");
        }
    }
}