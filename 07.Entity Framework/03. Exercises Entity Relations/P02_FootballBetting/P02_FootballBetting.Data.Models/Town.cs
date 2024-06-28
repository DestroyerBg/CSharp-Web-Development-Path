using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Town
    {
        public Town()
        {
            Teams = new HashSet<Team>();
            Players = new HashSet<Player>();
        }
        [Key]
        public int TownId { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<Player> Players { get; set; }

    }
}
