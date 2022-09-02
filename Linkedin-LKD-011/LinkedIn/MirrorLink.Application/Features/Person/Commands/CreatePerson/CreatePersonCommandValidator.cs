//using FluentValidation;
//using MirrorLink.Application.Features.Person.Queries.GetPersonList;

//namespace MirrorLink.Application.Features.Person.Commands.CreatePerson
//{
//    public class CreatePersonCommandValidator : AbstractValidator<GetPersonListQuery>
//    {
//        public CreatePersonCommandValidator()
//        {
//            RuleFor(p => p.FirstName)
//                .NotEmpty().WithMessage("{PropertyName} is required")
//                .NotNull().WithMessage("{PropertyName} can't be null")
//                .MaximumLength(50).WithMessage("{PropertyName} can't be null");
//        }
//    }
//}