namespace ForumASPMVC.Models.ViewModels
{
    public class CreateCommentViewModel
    {
        public string? Title { get; set; }
        public string? Text { get; set; }
        public int ThreadOneId { get; set; }
    }
}
