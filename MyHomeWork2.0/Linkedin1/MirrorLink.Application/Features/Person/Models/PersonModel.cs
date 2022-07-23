using MirrorLink.Domain.Entities;
using System.Collections.Generic;

namespace MirrorLink.Application.Features.Person.Models
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
       // public List<PetModel> Pets { get; set; }
    }
}
