using System.ComponentModel.DataAnnotations;
using static CinemaApp.Data.Constraints.CinemaConstraints;
namespace CinemaApp.ViewModels
{
    public class CinemaIndexViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = NameErrorMessage)]
        [StringLength(NameMaxLength, ErrorMessage = NameTooLongErrorMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = LocationErrorMessage)]
        [StringLength(LocationMaxLength, ErrorMessage = LocationTooLongErrorMessage)]
        public string Location { get; set; } = null!;


    }
}
