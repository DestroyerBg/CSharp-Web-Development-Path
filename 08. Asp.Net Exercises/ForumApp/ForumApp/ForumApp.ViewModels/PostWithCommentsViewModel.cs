using ForumApp.ViewModels.CommentModels;

namespace ForumApp.ViewModels
{
    public class PostWithCommentsViewModel
    {
        public Guid PostId { get; set; }

        public string PostContent { get; set; } = null!;

        public string PostTitle { get; set; } = null!;


        public ICollection<CommentViewModel> Comments { get; set; } = new HashSet<CommentViewModel>();


    }
}
