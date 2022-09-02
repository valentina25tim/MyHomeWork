using System;

namespace MirrorLink.Business.Entities
{
    public class Certificate : Entity
    {
        public string CategoryName { get; set; }
        public string IssuedBy { get; set; }
        public DateTime Date { get; set; }
    }
}
