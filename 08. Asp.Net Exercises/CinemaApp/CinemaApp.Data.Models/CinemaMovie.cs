using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.Data.Models
{
    public class CinemaMovie
    {
        [ForeignKey(nameof(Cinema))]
        public Guid CinemaId { get; set; }

        public Cinema Cinema { get; set; } = null!;

        [ForeignKey(nameof(Movie))]
        public Guid MovieId { get; set; }

        public Movie Movie { get; set; } = null!;
    }
}
