using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MirrorLink.Application.Contracts.Persistence;

namespace MirrorLink.Application.Features.Person.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public CreateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAddressCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await new CreateAddressCommandValidator()
                .ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid)
            {
                var address = _mapper.Map<Domain.Entities.Address>(command);
                var result = await _addressRepository.AddAsync(address, cancellationToken);

                return result.Id;
            }

            //TODO Send error to the user and log error
            return 0;
        }
    }
}