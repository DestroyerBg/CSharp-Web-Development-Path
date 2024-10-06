using System.ComponentModel.DataAnnotations;
using static ForumApp.Common.DatabaseConstants.PostConstants;
namespace ForumApp.ViewModels.PostModels
{
    public class ImportPostUpdateViewModel
    {
        [Required]
        public string PostId { get; set; } = null!;

        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(ContentMinLength)]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;
    }
}
