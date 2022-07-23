using AutoMapper;
using MediatR;
using MirrorLink.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace MirrorLink.Application.Features.Person.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public CreatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }
        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await new CreatePersonCommandValidator()
                .ValidateAsync(request, cancellationToken);

            if(validationResult.IsValid)
            {
                var person = _mapper.Map<Microsoft.Domain.Entities.Person>(request);
                var result = await _personRepository.AddAsync(person, cancellationToken);

                return result.Id;
            }

            return 0;
        }
    }
}
