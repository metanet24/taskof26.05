namespace FiorelloFrontBackDB.Models
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date {  get; set; } = DateTime.Now;
        public string Image {  get; set; }
    }
}
