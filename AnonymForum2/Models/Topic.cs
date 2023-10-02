namespace AnonymForum2.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Post> Posts { get; set; } //one to many
    }
}
