using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnonymForum2.Models.ViewModel
{
    public class PostCreateViewModel
    {
        [DisplayName("Titel")]
        [Required(ErrorMessage = "Rutan får inte vara tom")]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Text")]
        [Required(ErrorMessage = "Rutan får inte vara tom")]
        public string Contents { get; set; }
        public DateTime PostTime { get; set; }
        public int FKTopicId { get; set; }
    }
}