
using MediatR;
using MirrorLink.Application.Contracts.Models;

namespace MirrorLink.Application.Features.Person.Queries.PostPerson
{
    public class PostPersonListQuery : IRequest<PersonModel>
    {
        public PersonModel Model { get; set; }

        public PostPersonListQuery(PersonModel person)
        {
            Model = person;
        }
    }
}
