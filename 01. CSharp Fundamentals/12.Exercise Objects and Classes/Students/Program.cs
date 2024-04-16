using System.Diagnostics;

namespace Students
{
    class Student
    {
        public Student(string studentFirstName, string studentLastName, double studentGrade)
        {
            FirstName = studentFirstName;
            LastName = studentLastName;
            Grade = studentGrade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
           
            for (int i = 0; i < countOfStudents; i++)
            {
                List<string> studentInfo = Console
                    .ReadLine()
                    .Split()
                    .ToList();
                    string studentFirstName = studentInfo[0];
                    string studentLastName = studentInfo[1];
                    double studentGrade = double.Parse(studentInfo[2]);
                    Student student = new Student(studentFirstName,studentLastName,studentGrade);
                    students.Add(student);
                   students = students.OrderByDescending(grade => grade.Grade).ToList();

            }

            foreach (Student anyStudent in students)
            {
                Console.WriteLine($"{anyStudent.ToString()}");
            }
            
        }
    }
}