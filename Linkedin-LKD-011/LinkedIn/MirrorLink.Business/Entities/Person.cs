using System.Collections.Generic;
using MirrorLink.Business.Entities;

namespace MirrorLink.Domain.Entities
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Address? Address { get; set; }
        public ContactInfo? ContactInfo { get; set; }
        public CurrentStatus? CurrentStatus { get; set; }
        public AdditionInfo? AdditionInfo { get; set; }
        public IEnumerable<WorkExperience>? WorkExperiences { get; set; }
        public IEnumerable<Certificate>? Certificates { get; set; }
        public IEnumerable<Skill>? Skills { get; set; }
        public IEnumerable<Language>? Languages { get; set; }
        public IEnumerable<Attachment>? Attachments { get; set; }
        public IEnumerable<Education>? Educations { get; set; }
    }
}
