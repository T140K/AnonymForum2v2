using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AnonymForum2.Models.ViewModel
{
    public class ReplyCreateViewModel
    {
        [DisplayName("Svaret")]
        [Required(ErrorMessage = "Rutan får inte vara tom")]
        public string Contents { get; set; }
        public DateTime ReplyDate { get; set; }
        public int FKPostId { get; set; }
    }
}
