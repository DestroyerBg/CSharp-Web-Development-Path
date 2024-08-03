using System.ComponentModel.DataAnnotations;
using static TravelAgency.Data.Common.DatabaseConstraints;
namespace TravelAgency.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CustomerFullNameMaxlength)]
        public string FullName { get; set; } = null!;

        [Required]
        [MaxLength(CustomerEmailMaxlength)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(CustomerPhoneNumberExactlyLength)]
        public string PhoneNumber { get; set; } = null!;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
