using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MirrorLink.Application.Contracts.Persistence;
using MirrorLink.Application.Features.Person.Models;
using MirrorLink.Application.Features.Person.Queries.GetPersonList;

namespace MirrorLink.Application.Features.Person.Queries.GetPersonDetailQuery
{

    public class GetPersonIDListQueryHandler : IRequestHandler<GetPersonDetailQuery, PersonModel>
    {
        private readonly IAsyncRepository<Domain.Entities.Person> _repository;
        private readonly IMapper _mapper;

        public GetPersonIDListQueryHandler(IAsyncRepository<Domain.Entities.Person> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PersonModel> Handle(GetPersonDetailQuery request, CancellationToken cancellationToken)
        {
            var person = await _repository.GetByIdAsync(request.Id, cancellationToken);
            return _mapper.Map <PersonModel> (person);
        }
        
    }
}
