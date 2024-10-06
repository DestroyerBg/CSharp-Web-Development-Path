using System.ComponentModel.DataAnnotations;
using static ForumApp.Common.DatabaseConstants.PostConstants;
namespace ForumApp.ViewModels.PostModels
{
    public class ImportPostViewModel
    {
        [Required(ErrorMessage = "Post Title should be between 5 and 30 symbols long!")]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        [Display(Name = "Post Title")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Content should be between 10 and 2000 symbols long!")]
        [MinLength(ContentMinLength)]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

    }
}
