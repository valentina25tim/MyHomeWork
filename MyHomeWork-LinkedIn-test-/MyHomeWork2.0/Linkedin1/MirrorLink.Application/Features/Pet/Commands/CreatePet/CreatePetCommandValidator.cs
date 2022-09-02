using FluentValidation;

namespace MirrorLink.Application.Features.Person.Commands.CreatePerson
{
    public class CreatePetCommandValidator : AbstractValidator<CreatePetCommand>
    {
        public CreatePetCommandValidator()
        {
            RuleFor(p => p.Type)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} can't be null")
                .MaximumLength(50).WithMessage("{PropertyName} can't be null");
        }
    }
}