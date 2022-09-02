using FluentValidation;

namespace MirrorLink.Application.Features.Person.Commands.CreateAddress
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(p => p.Country)
                .NotEmpty().WithMessage("{PropertyCountry} is required")
                .NotNull().WithMessage("{PropertyCountry} can't be null")
                .MaximumLength(50).WithMessage("{PropertyCountry} can't be null");
        }
    }
}
