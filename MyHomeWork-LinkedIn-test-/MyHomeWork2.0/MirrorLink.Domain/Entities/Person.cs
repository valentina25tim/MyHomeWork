using MirrorLink.Business.Entities;
using System.Collections.Generic;

namespace MirrorLink.Domain.Entities
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
       // public List<Pet> Pets { get; set;  }
    }
}
