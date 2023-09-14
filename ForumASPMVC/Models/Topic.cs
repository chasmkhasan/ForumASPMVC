

using System.ComponentModel.DataAnnotations;

namespace ForumASPMVC.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Created { get; set; }

        public List<ThreadOne>? Threads { get; set; }
    }
}
