namespace MirrorLink.Business.Entities
{
    public class Attachment : Entity
    {
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
    }
}