using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using MirrorLink.Application.Contracts.Persistence;

namespace MirrorLink.Application.Features.Person.Commands.CreatePerson
{
    //public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, int>
    //{
    //    private readonly IMapper _mapper;
    //    private readonly IPetRepository _personRepository;

    //    public CreatePetCommandHandler(IPetRepository personRepository, IMapper mapper)
    //    {
    //        _personRepository = personRepository;
    //        _mapper = mapper;
    //    }

    //    public async Task<int> Handle(CreatePetCommand command,CancellationToken cancellationToken)
    //    {
    //        var validationResult = await new CreatePetCommandValidator()
    //            .ValidateAsync(command, cancellationToken);

    //        if (validationResult.IsValid)
    //        {
    //            var person = _mapper.Map<Domain.Entities.Pet>(command);

    //            var result = await _personRepository.AddAsync(person,cancellationToken);

    //            return result.Id;
    //        }

    //        //TODO Send error to the user and log error
    //        return 0;
    //    }

    //}
}