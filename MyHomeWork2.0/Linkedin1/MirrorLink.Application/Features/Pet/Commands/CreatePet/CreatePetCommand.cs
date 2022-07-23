using MediatR;

namespace MirrorLink.Application.Features.Person.Commands.CreatePerson
{
    public class CreatePetCommand : IRequest<int>
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}