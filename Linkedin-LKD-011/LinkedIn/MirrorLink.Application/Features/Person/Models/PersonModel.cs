
using MirrorLink.Domain.Entities;

namespace MirrorLink.Application.Contracts.Models
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public AddressModel Address { get; set; }

        //TODO Fill in other props with models
    }
}