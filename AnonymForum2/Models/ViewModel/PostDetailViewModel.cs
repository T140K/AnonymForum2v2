namespace AnonymForum2.Models.ViewModel
{
    public class PostDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime PostTime { get; set; }
        public int FKTopicId { get; set; }
    }
}
