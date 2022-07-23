using MediatR;
using MirrorLink.Application.Features.Person.Models;
using System.Collections.Generic;

namespace MirrorLink.Application.Features.Person.Queries
{
    public class GetPersonListQuery : IRequest <List<PersonModel>>
    {
    }
}
