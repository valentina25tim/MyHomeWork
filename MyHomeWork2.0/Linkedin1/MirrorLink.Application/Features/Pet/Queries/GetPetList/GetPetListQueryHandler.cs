using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MirrorLink.Application.Contracts.Persistence;
using MirrorLink.Application.Features.Person.Models;

namespace MirrorLink.Application.Features.Pet.Queries.GetPetList
{
    public class GetPetListQueryHandler : IRequestHandler<GetPetListQuery, List<PetModel>>
    {
        private readonly IAsyncRepository<Domain.Entities.Pet> _repository;
        private readonly IMapper _mapper;

        public GetPetListQueryHandler(IAsyncRepository<Domain.Entities.Pet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PetModel>> Handle(GetPetListQuery request, CancellationToken cancellationToken)
        {
            var persons = await _repository.ListAllAsync(cancellationToken);
            return _mapper.Map<List<PetModel>>(persons);
        }
    }
}
