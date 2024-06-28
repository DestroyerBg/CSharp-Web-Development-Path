using P02_FootballBetting.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            HomeGames = new HashSet<Game>();
            AwayGames = new HashSet<Game>();
            Players = new HashSet<Player>();
        }
        [Key]
        public int TeamId { get; set; }
        [Required]
        public string Name { get; set; }

        public string LogoUrl { get; set; }
        [MaxLength(DatabaseConstraints.InitialsTextLimit)]
        public string Initials { get; set; }

        public decimal Budget { get; set; }
        [ForeignKey(nameof(PrimaryKitColorId))]
        public int PrimaryKitColorId { get; set; }

        public virtual Color PrimaryKitColor { get; set; }
        [ForeignKey(nameof(SecondaryKitColorId))]
        public int SecondaryKitColorId { get; set; }

        public virtual Color SecondaryKitColor { get; set; }
        [ForeignKey(nameof(TownId))]
        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        public ICollection<Game> HomeGames { get; set; }

        public ICollection<Game> AwayGames { get; set; }

        public ICollection<Player> Players { get; set; }
 
    }
}
