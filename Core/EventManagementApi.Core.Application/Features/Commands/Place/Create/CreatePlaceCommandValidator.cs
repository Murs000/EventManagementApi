using FluentValidation;

namespace EventManagementApi.Core.Application.Features.Commands.Place.Create
{
    public class CreatePlaceCommandValidator : AbstractValidator<CreatePlaceCommand>
    {
        public CreatePlaceCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Place name is required")
                .MaximumLength(100).WithMessage("Place name can't exceed 100 characters");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Place address is required")
                .MaximumLength(200).WithMessage("Address can't exceed 200 characters");
        }
    }
}