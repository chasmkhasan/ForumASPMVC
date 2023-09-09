using System.Xml.Linq;

namespace ForumASPMVC.Models
{
    public class ThreadOne
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public int TopicId { get; set; } // Required foreign key property

        public Topic Topic { get; set; } // Required reference navigation to principal
        public List<Comment>? Comments { get; set; }
    }
}
