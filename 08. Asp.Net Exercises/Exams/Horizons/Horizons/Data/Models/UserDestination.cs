using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Horizons.Data.Models
{
    public class UserDestination
    {
        
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        [Required]
        public IdentityUser User { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Destination))]
        public int DestinationId { get; set; }

        [Required]
        public Destination Destination { get; set; } = null!;
    }
}