using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using MirrorLink.Application.Contracts.Models;
using MirrorLink.Application.Contracts.Persistence;
using MirrorLink.Application.Features.Person.Commands.UpdatePerson;
using MirrorLink.Application.Features.Person.Queries.PostPerson;

namespace MirrorLink.Application.Features.Person.Queries.PostPersonList
{
    // need toDo Validation and  Id

    public class PostPersonListQueryHandler : IRequestHandler<PostPersonListQuery, PersonModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        private readonly IValidator<PostPersonListQuery> _personVaidator;

        public PostPersonListQueryHandler(IMapper mapper, IPersonRepository personRepository, IValidator<PostPersonListQuery> personVaidator)
        {
            _mapper = mapper;
            _personRepository = personRepository;
            _personVaidator = personVaidator;
        }

        public async Task<PersonModel> Handle(PostPersonListQuery request, CancellationToken cancellationToken)
        {
            PersonModel person = request.Model;

            //try
            //{
            //    var result = _personVaidator.Validate((IValidationContext)person);
            //}
            //catch
            //{
            //    //var errors = result.Errors.Select(e => e.ErrorMessage).ToArray();
            //    return null;
            //}
            var newPerson = new PersonModel()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Id = person.Id,
                Address = person.Address

            };

            var thisPerson = await _personRepository.AddAsync(_mapper.Map<Domain.Entities.Person>(newPerson), cancellationToken);
            return newPerson;
        }
    }
}
