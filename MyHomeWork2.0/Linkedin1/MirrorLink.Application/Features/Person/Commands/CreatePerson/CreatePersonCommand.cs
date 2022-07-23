using MediatR;
using MirrorLink.Application.Features.Person.Models;
using MirrorLink.Domain.Entities;
using System.Collections.Generic;

namespace MirrorLink.Application.Features.Person.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
       // public List<PetModel> Pets { get; set; }
    }
}