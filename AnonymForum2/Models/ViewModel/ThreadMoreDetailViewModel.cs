namespace AnonymForum2.Models.ViewModel
{
    public class ThreadMoreDetailViewModel
    {
        public List<ThreadDetailViewModel> Replies { get; set; }
        public int postId { get; set;}
        public List<PostDetailViewModel> Post { get; set; }
    }
}
