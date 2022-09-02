namespace MirrorLink.Business.Entities
{
    public class CurrentStatus : Entity
    {
        public bool WaitOffer { get; set; }
        public string SectorJob { get; set; }
        public string Role { get; set; }
        public string TypeJob { get; set; }
    }
}