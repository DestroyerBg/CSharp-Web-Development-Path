using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {

        public StudentSystemContext()
        {
            
        }

        public StudentSystemContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(pk => new
                {
                    pk.StudentId, pk.CourseId
                });

            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasMany(e => e.StudentsCourses);

                entity.HasMany(e => e.Homeworks);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasMany(e => e.Homeworks);

                entity.HasMany(e => e.Resources);
            });

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }


    }
}
