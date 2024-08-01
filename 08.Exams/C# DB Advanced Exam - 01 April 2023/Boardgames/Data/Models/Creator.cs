﻿using System.ComponentModel.DataAnnotations;
using static Boardgames.Data.Common.DatabaseConstraints;
namespace Boardgames.Data.Models
{
    public class Creator
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CreatorFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(CreatorLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public ICollection<Boardgame> Boardgames { get; set; } = new List<Boardgame>();
    }
}