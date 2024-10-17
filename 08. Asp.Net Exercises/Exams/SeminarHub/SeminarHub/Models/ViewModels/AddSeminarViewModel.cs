using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SeminarHub.Attributes;
using static SeminarHub.Constraints.SeminarConstraints;
using SeminarHub.Data.DatabaseModels;
namespace SeminarHub.Models.ViewModels
{
    public class AddSeminarViewModel
    {
        [Required]
        [WordLength(TopicMinLength, TopicMaxLength, TopicErrorMessage)]
        public string Topic { get; set; } = null!;

        [Required]
        [WordLength(LecturerMinLength, LecturerMaxLength, LecturerErrorMessage)]
        public string Lecturer { get; set; } = null!;

        [Required]
        [WordLength(DetailsMinLength, DetailsMaxLength, DetailsErrorMessage)]
        public string Details { get; set; } = null!;

        [Required]
        public string OrganizerId { get; set; } = null!;

        [Required]
        [Date(DateAndTimeFormat, DateWrongFormatErrorMessage)]
        public string DateAndTime { get; set; }

        [Required]
        [Range(DurationMinValue, DurationMaxValue, ErrorMessage = DurationErrorMessage)]
        public int Duration { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public ICollection<Category> Categories { get; set; } = new HashSet<Category>();

    }
}
