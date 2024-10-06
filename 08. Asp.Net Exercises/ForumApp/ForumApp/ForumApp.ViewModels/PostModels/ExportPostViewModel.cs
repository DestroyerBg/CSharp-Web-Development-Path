namespace ForumApp.ViewModels.PostModels
{
    public class ExportPostViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
