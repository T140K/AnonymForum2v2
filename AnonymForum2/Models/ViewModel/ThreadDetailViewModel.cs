using System.ComponentModel.DataAnnotations;

namespace AnonymForum2.Models.ViewModel
{
    public class ThreadDetailViewModel
    {
        [DataType(DataType.MultilineText)]
        public string Contents { get; set; }
        public DateTime ReplyDate { get; set; }
        public int FKPostId { get; set; }
    }
}
