﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            StudentsCourses = new HashSet<StudentCourse>();
            Homeworks = new HashSet<Homework>();
        }
        [Key]
        public int StudentId { get; set; }

        [Required] [MaxLength(100)] [Unicode] public string Name { get; set; } 

        [MinLength(10)] [MaxLength(10)] public string? PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }
        
        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> StudentsCourses { get; set; }
        public ICollection<Homework> Homeworks { get; set; }



    }
}
