using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcademicRecordsApp.Data.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
            StudentsCourses = new HashSet<StudentCourse>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; }

        public virtual ICollection<StudentCourse> StudentsCourses { get;}
    }
}
