using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MirrorLink.Application.Contracts.Persistence;
using MirrorLink.Application.Contracts.Models;

namespace MirrorLink.Application.Features.Person.Queries.GetPersonList
{
    public class GetPersonListQueryHandler : IRequestHandler<GetPersonListQuery, List<PersonModel>>
    {
        private readonly IAsyncRepository<Domain.Entities.Person> _repository;
        private readonly IMapper _mapper;

        public GetPersonListQueryHandler(IAsyncRepository<Domain.Entities.Person> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PersonModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            var persons = await _repository.ListAllAsync(cancellationToken);
            return _mapper.Map<List<PersonModel>>(persons);
        }
    }
}
