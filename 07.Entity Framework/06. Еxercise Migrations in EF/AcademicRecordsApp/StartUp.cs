using System.Threading.Channels;
using AcademicRecordsApp.Data;

using var context = new AcademicRecordsDBContext();

var students = context.Students.ToList();
students.ForEach(student => Console.WriteLine(student.FullName));