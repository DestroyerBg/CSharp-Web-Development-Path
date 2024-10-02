using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using static ForumApp.Common.DatabaseConstants.PostConstants;
namespace ForumApp.Data.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; init; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;
    }
}
