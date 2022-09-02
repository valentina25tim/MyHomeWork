using System.Collections.Generic;
using MediatR;
using MirrorLink.Application.Contracts.Models;

namespace MirrorLink.Application.Features.Person.Queries.GetPersonList
{
    public class GetPersonListQuery : IRequest<List<PersonModel>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel Address { get; set; }
    }
}
