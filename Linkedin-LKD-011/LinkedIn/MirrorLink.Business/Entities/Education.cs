using System;

namespace MirrorLink.Business.Entities
{
    public class Education : Entity
    {
        public string NameEstablishment { get; set; }
        public string Speciality { get; set; }
        public string Degree { get; set; }
        public DateTime StudyBegin { get; set; }
        public DateTime StudyFinish { get; set; }
    }
}
