using MirrorLink.Business.Entities;

namespace MirrorLink.Domain.Entities
{
    public class Address : Entity
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}
