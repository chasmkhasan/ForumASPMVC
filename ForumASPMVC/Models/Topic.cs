namespace ForumASPMVC.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public List<ThreadOne> Threads { get; set; }
    }
}
