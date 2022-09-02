using System;

namespace MirrorLink.Business.Entities
{
    public class WorkExperience : Entity
    {
        public string NameCompany { get; set; }
        public string UrlCompany { get; set; }
        public string Role { get; set; }
        public string TypeJob { get; set; }
        public DateTime Started { get; set; }
        public DateTime Unemployed { get; set; }
        public int Duration { get; set; }
    }
}
