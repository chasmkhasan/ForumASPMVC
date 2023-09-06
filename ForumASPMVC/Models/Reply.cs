using System.Xml.Linq;

namespace ForumASPMVC.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string? Title { get; set; } // optional

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public int? CommentId { get; set; } // Optional foreign key property

        public Comment? Comment { get; set; } // Optional reference navigation to principal
    }
}
