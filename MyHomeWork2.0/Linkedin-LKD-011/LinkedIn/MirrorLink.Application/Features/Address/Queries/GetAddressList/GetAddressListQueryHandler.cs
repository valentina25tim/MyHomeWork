using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MirrorLink.Application.Contracts.Persistence;
using MirrorLink.Application.Features.Address.Queries.GetPersonList;
using MirrorLink.Application.Contracts.Models;

namespace MirrorLink.Application.Features.Person.Queries.GetAddressList
{
    public class GetAddressListQueryHandler : IRequestHandler<GetAddressListQuery, List<AddressModel>>
    {
        private readonly IAsyncRepository<Domain.Entities.Address> _repository;
        private readonly IMapper _mapper;

        public GetAddressListQueryHandler(IAsyncRepository<Domain.Entities.Address> repository, IMapper mapper)
        { 
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<AddressModel>> Handle(GetAddressListQuery request, CancellationToken cancellationToken)
        {
            var address = await _repository.ListAllAsync(cancellationToken);
            return _mapper.Map<List<AddressModel>>(address);
        }
    }
}
