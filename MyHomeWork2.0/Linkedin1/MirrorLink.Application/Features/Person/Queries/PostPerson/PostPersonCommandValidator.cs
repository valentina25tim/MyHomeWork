using FluentValidation;
using MirrorLink.Application.Features.Person.Queries.PostPerson;
using System;

namespace MirrorLink.Application.Features.Person.Commands.UpdatePerson
{
    public class PostPersonCommandValidator : AbstractValidator<PostPersonListQuery>
    {
        public PostPersonCommandValidator()
        {
            RuleFor(p => p.Model.FirstName)
             .NotEmpty().WithMessage("{PropertyFName} is required")
             .NotNull().WithMessage("{PropertyFName} can't be null")
             .MaximumLength(50).WithMessage("{PropertyFName} can't be null");

            RuleFor(p => p.Model.LastName)
             .NotEmpty().WithMessage("{PropertyName} is required")
             .NotNull().WithMessage("{PropertyName} can't be null")
             .MaximumLength(50).WithMessage("{PropertyName} can't be null");

            RuleFor(p => p.Model.Age)
                .GreaterThan(100).WithMessage("{PropertyAge} can`t be greather than 100")
                .LessThan(1).WithMessage("{PropertyAge} can`t be less than 1");
        }
    }
}
