﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Models
{
    public class Product
    {
        public Product()
        {
            CategoryProducts = new HashSet<CategoryProduct>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Buyer))]
        public int? BuyerId { get; set; }

        public User Buyer { get; set; }
        [ForeignKey(nameof(Seller))]
        public int SellerId { get; set; }

        public User Seller { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
