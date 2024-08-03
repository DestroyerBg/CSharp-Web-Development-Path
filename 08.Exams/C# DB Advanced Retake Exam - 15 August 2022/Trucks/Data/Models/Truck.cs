using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trucks.Data.Models.Enums;
using static Trucks.Data.Common.DatabaseConstraints;
namespace Trucks.Data.Models
{
    public class Truck
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TruckRegistrationNumberExactlyLength)]
        public string RegistrationNumber { get; set; } = null!;

        [Required]
        [MaxLength(TruckVinNumberExactlyLength)] 
        public string VinNumber { get; set;} = null!;

        [Required]
        public int TankCapacity { get; set; }

        [Required]
        public int CargoCapacity { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        public MakeType MakeType { get; set; }

        [Required]
        [ForeignKey(nameof(Despatcher))]
        public int DespatcherId { get; set; }

        public Despatcher Despatcher { get; set; }

        public ICollection<ClientTruck> ClientsTrucks { get; set; } = new List<ClientTruck>();

    }
}
