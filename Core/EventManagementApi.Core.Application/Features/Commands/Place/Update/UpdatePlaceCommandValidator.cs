using FluentValidation;

namespace EventManagementApi.Core.Application.Features.Commands.Place.Update
{
    public class UpdatePlaceCommandValidator : AbstractValidator<UpdatePlaceCommand>
    {
        public UpdatePlaceCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Valid Place ID is required");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Place name is required")
                .MaximumLength(100).WithMessage("Place name can't exceed 100 characters");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Place address is required")
                .MaximumLength(200).WithMessage("Address can't exceed 200 characters");
        }
    }
}