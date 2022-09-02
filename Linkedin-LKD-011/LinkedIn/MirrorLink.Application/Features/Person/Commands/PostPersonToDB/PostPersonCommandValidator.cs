using FluentValidation;
using MirrorLink.Application.Features.Person.Queries.PostPerson;
using System;

namespace MirrorLink.Application.Features.Person.Commands.UpdatePerson
{
    public class UpdatePersonCommandValidator : AbstractValidator<PostPersonListQuery>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(p => p.Model.FirstName)
             .NotEmpty().WithMessage("{PropertyFName} is required")
             .NotNull().WithMessage("{PropertyFName} can't be null")
             .MaximumLength(50).WithMessage("{PropertyFName} can't be null");

            RuleFor(p => p.Model.LastName)
             .NotEmpty().WithMessage("{PropertyName} is required")
             .NotNull().WithMessage("{PropertyName} can't be null")
             .MaximumLength(50).WithMessage("{PropertyName} can't be null");

        }
    }
}
