﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class User
    {
        public User()
        {
            Bets = new HashSet<Bet>();
        }
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public decimal Balance { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}
