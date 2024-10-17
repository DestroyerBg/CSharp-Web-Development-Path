using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static SeminarHub.Constraints.SeminarConstraints;
namespace SeminarHub.Data.DatabaseModels
{
    public class Seminar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TopicMaxLength)]
        public string Topic { get; set; } = null!;

        [Required]
        [MaxLength(LecturerMaxLength)]
        public string Lecturer { get; set; } = null!;

        [Required]
        [MaxLength(DetailsMaxLength)]
        public string Details { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Organizer))]
        public string OrganizerId { get; set; } = null!;

        [Required]
        public IdentityUser Organizer { get; set; } = null!;

        [Required]
        public DateTime DateAndTime { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;

        public ICollection<SeminarParticipant> SeminarsParticipants { get; set; } = new HashSet<SeminarParticipant>();
    }
}
