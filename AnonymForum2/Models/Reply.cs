namespace AnonymForum2.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string Contents { get; set; }
        public DateTime ReplyDate { get; set; }
        public int FKPostId { get; set; }

        public Post Post { get; set; } //many to one
    }
}
