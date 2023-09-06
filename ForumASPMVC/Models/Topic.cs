namespace ForumASPMVC.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public int Title { get; set; }

        public int Description { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public List<ThreadOne> Threads { get; set; }
    }
}
