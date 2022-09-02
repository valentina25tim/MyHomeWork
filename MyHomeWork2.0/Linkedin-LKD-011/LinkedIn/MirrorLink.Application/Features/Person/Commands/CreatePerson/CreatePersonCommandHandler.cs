//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using AutoMapper;
//using MediatR;
//using MirrorLink.Application.Contracts.Persistence;
//using MirrorLink.Application.Features.Person.Commands.CreateAddress;

//namespace MirrorLink.Application.Features.Person.Commands.CreatePerson
//{
//    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
//    {
//        private readonly IMapper _mapper;
//        private readonly IPersonRepository _personRepository;

//        public CreatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
//        {
//            _personRepository = personRepository;
//            _mapper = mapper;
//        }

//        public async Task<int> Handle(CreatePersonCommand command,CancellationToken cancellationToken)
//        {
//            var validationResult = await new CreatePersonCommandValidator()
//                .ValidateAsync(command, cancellationToken);

//            if (validationResult.IsValid)
//            {
//                var person = _mapper.Map<Domain.Entities.Person>(command);

//                var result = await _personRepository.AddAsync(person,cancellationToken);

//                return result.Id;
//            }

//            //TODO Send error to the user and log error
//            return 0;
//        }

//    }
//}