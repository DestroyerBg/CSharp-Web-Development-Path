﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        public Player()
        {
            PlayersStatistics = new HashSet<PlayerStatistic>();
        }
        [Key]
        public int PlayerId { get; set; }

        [Required]
        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public bool IsInjured { get; set; }
        [ForeignKey(nameof(PositionId))]
        public int PositionId { get; set; }

        public virtual Position Position { get; set; }
        [ForeignKey(nameof(TeamId))]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
        [ForeignKey(nameof(TownId))]
        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        public ICollection<PlayerStatistic> PlayersStatistics { get; set; }

    }
}
