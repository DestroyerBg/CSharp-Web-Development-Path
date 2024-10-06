using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static ForumApp.Common.DatabaseConstants.CommentConstants;
namespace ForumApp.ViewModels.CommentModels
{
    public class CommentViewModel
    {
        public CommentViewModel()
        {
            PublishedDate = DateTime.Today;
        }
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength, ErrorMessage = UsernameErrorMessage)]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength, ErrorMessage = ContentErrorMessage)]

        public string Content { get; set; } = null!;

        [Required]
        public DateTime PublishedDate { get; set; }

        [Required]
        public Guid PostId { get; set; }

    }
}
