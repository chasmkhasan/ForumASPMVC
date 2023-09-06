namespace ForumASPMVC.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Title { get; set; } // optional

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public int? ThreadOneId { get; set; } // Optional foreign key property

        public ThreadOne? Thread { get; set; } // Optional reference navigation to principal

        public List<Reply> Replies { get; set; }
    }
}
