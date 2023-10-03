namespace AnonymForum2.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime PostTime { get; set; }
        public int FKTopicId { get; set; }

        public Topic Topic { get; set; } //many to one
        public List<Reply> Replies { get; set; } //one to many
    }
}