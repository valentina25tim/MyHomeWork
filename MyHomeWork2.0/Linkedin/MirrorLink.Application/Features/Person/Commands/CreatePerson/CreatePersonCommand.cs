using MediatR;

namespace MirrorLink.Application.Features.Person.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest <int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
