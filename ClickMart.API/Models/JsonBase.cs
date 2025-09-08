namespace ClickMart.API.Models
{
    public class JsonBase
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime? DeletionDate { get; set; } = null;
    }
}
