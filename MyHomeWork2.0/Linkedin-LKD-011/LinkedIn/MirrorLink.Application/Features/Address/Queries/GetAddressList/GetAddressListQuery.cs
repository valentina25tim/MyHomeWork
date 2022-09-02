using System.Collections.Generic;
using MediatR;
using MirrorLink.Application.Contracts.Models;

namespace MirrorLink.Application.Features.Address.Queries.GetPersonList
{
    public class GetAddressListQuery : IRequest<List<AddressModel>>
    {
    } 
}
