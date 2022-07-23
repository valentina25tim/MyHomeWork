using MirrorLink.Business.Entities;

namespace MirrorLink.Domain.Entities
{
    public class Pet : Entity
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
